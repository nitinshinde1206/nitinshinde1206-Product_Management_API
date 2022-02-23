using Microsoft.Extensions.Logging;
using Product_ManagementAPI.Interfaces;
using Product_ManagementAPI.Models;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_ManagementAPI.Services
{
    public class ProductService : IProduct
    {

        private readonly QueryFactory _db;
        private readonly ILogger<ProductService> _logger;

        public ProductService(QueryFactory db)
        {
            _db = db;
        }

        public bool Add(Product item)
        {
           
            try
            {
                var query = _db.Query("ProductDetails").Insert(new
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductCode = item.ProductCode,
                    Price = item.Price,
                    Description = item.Description,
                    StarRating = item.StarRating,
                    ImageUrl = item.ImageUrl
                });
                return true;
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.ToString());
                return false;
            }
            
        }

        public Product Get(int id)
        {
            return _db.Query("ProductDetails")
                .Select("ProductDetails.ProductId", "ProductDetails.ProductName", "ProductDetails.Price",
                 "ProductDetails.ProductCode", "ProductDetails.Description", "ProductDetails.StarRating",
                 "ProductDetails.ImageUrl")
               .Where("ProductDetails.ProductId", "=", id).First<Product>();
        }

        public IEnumerable<Product> GetAll()
        {
            var x = _db.Query("ProductDetails")
                 .Select("ProductDetails.ProductId", "ProductDetails.ProductName", "ProductDetails.Price",
                 "ProductDetails.ProductCode", "ProductDetails.Description", "ProductDetails.StarRating",
                 "ProductDetails.ImageUrl").Get<Product>();

            return x; 
        }

        public bool Remove(int id)
        {
            try
            {
                var x = _db.Query("ProductDetails").Where("ProductId", "=", id).Delete();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return false;
            }
        }

        public bool Update(Product item)
        {           

            try
            {
                var query = _db.Query("ProductDetails").Where("ProductId", "=", item.ProductId).Update(new
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductCode = item.ProductCode,
                    Price = item.Price,
                    Description = item.Description,
                    StarRating = item.StarRating,
                    ImageUrl = item.ImageUrl
                });
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return false;
            }
        }
    }
}
