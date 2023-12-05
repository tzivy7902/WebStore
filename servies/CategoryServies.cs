using Entytess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class CategoryServies:ICategoryServies
    {
        ICategoryRepository _categoryRepository;
        public CategoryServies(ICategoryRepository _CategoryRepository) { 
            _categoryRepository = _CategoryRepository;
        }


        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();

        }

      


    }
}
