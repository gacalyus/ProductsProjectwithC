using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallbycategoryid")]
        public IActionResult GetAllByCategoryId(int id)
        {

            var result = _productService.GetAllByCategoryId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getproductdetail")]
        public IActionResult GetProductDetails(decimal min, decimal max)
        {

            var result = _productService.GetProductDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getallbyunitprice")]
        public IActionResult GetAllByUnitPrice(decimal min, decimal max)
        {

            var result = _productService.GetAllByUnitPrice(min, max);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpPost("add")]
        public IActionResult Add(Product product)
        {

            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
