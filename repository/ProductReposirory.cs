﻿using Entytess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ProductReposirory : IProductRepository
    {
        private readonly StoreDatabaseContext _dbContext;
        public ProductReposirory(StoreDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {

            return await _dbContext.Products.ToListAsync();

        }

        public async Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
            int?[] categoryIds)
        {
            var quary = _dbContext.Products.Where(product => 
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price).Include(i=>i.Category);
            List<Product> products = await quary.ToListAsync();
            return products;

        }
       
    }
}
