using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product {ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15},
                 new Product {ProductId=2,CategoryId=2,ProductName="Kamera" ,UnitPrice=45},
                  new Product {ProductId=3,CategoryId=2,ProductName="Mouse",UnitPrice=11},
                   new Product {ProductId=4,CategoryId=3,ProductName="Klavye",UnitPrice=58}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }


        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToUpdate);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductId = product.ProductId;
         //   productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where  İçindeki şarta uyan tüm elemanları yeni bir liste haline getirip döner
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
