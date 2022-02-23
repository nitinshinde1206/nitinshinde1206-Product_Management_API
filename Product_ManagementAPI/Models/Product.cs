using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_ManagementAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
