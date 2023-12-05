using Entytess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class CategoryRepository:ICategoryRepository
    {

        private readonly StoreDatabaseContext _dbContext;
        public CategoryRepository(StoreDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

         public async Task<IEnumerable<Category>> GetAllCategory()
        {

            return await _dbContext.Categories.ToListAsync();

        }


       
    }
}
