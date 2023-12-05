using Entytess;
using Microsoft.AspNetCore.Mvc;
using repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class ProductServices : IProductServies
    {
        IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {

            return await _productRepository.GetAllProduct();

        }

        public async Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
            int?[] categoryIds)
        {
            return await _productRepository.getAllProducts( desc, minPrice,  maxPrice,
            categoryIds);

           

        }


    }
}
