using AutoMapper;
using Entytess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODT;
using servies;
using System.Collections.Generic;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductServies _product;
        private readonly IMapper _mapper;

        public ProductController(IProductServies _Product,IMapper mapper)
        {
            _product = _Product;
            _mapper = mapper;


        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
         [FromQuery]   int?[] categoryIds)
        {

          IEnumerable<Product> products=await  _product.getAllProducts(desc, minPrice, maxPrice,
            categoryIds);
            IEnumerable<ProductDTO> productdto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            if (productdto.Count() == 0)
            {
                return NoContent();
            }
            return Ok(productdto);
        }







    }

}