using Product_ManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_ManagementAPI.Interfaces
{
   public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        bool Add(Product item);
        bool Remove(int id);
        bool Update(Product item);
    }
}
