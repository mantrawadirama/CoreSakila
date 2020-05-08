using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository:RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await FindAll().OrderBy(p => p.ProductName).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await FindByCondition(p => p.ProductID.Equals(productId)).FirstOrDefaultAsync();
        }        
    }
}
