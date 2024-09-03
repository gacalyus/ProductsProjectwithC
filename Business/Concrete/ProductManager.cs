using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),
                CheckCategoryCount()
                );


            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları

            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), id + Messages.AllbyCategoryIdListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {

            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;

            if (result >= 10)
            {
                return new ErrorDataResult<List<Product>>(Messages.ProductCountError);
            }


            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 10)
            {
                return new ErrorDataResult<List<Product>>(Messages.ProductCountError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productDal.GetAll(p => p.ProductName == name).Any();
            if (result)
            {
                return new ErrorDataResult<List<Product>>(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckCategoryCount()
        {

            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
