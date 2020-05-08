using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
       Task<IEnumerable<Product>> GetAllProducts();
       Task<Product> GetProductById(int productId);
       
    }
}
