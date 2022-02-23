using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_ManagementAPI.Interfaces;
using Product_ManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_ManagementAPI.Controllers
{
    public class ProductServiceController : Controller
    {

        private readonly IProduct _product;
        public ProductServiceController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("GetAllProducts")]
        //[Authorize]
        public IEnumerable<Product> GetAllProducts()
        {
            return _product.GetAll();
        }

        [HttpGet("GetProductById/{id}")]
        //[Authorize]
        public Product GetProduct(int id)
        {
            return _product.Get(id);
        }


        [HttpPost("AddProduct")]
        //[Authorize]
        public bool AddProduct([FromBody] Product product)
        {
            return _product.Add(product);
        }


        [HttpPut("UpdateProduct")]
        //[Authorize]
        public bool UpdateProduct([FromBody]  Product product)
        {
            return _product.Update(product);
        }


        [HttpDelete("DeleteProduct/{id}")]
        //[Authorize]
        public bool DeleteProduct(int id)
        {
            return _product.Remove(id);
        }

    }
}
