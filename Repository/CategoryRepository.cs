using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
     public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await FindAll().OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetProductsByCategoryId(int categoryId)
        {
            return await FindByCondition(c => c.CategoryID.Equals(categoryId))
                .Include(p => p.Products)
                .FirstOrDefaultAsync();
        }
    }
}
