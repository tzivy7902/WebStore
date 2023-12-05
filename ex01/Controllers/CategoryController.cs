using AutoMapper;
using Entytess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODT;
using servies;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryServies _category;
        private readonly IMapper _CategoryMapper;


        public CategoryController(ICategoryServies _Category,IMapper mapper)

        {
            _CategoryMapper = mapper;
            _category = _Category;

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategory()
        {
            IEnumerable<Category> CategoryList = await _category.GetAllCategory();
            IEnumerable<CategoryDTO> CategoryListDTO = _CategoryMapper.Map< IEnumerable<Category>, IEnumerable< CategoryDTO >> (CategoryList);
            if (CategoryListDTO.Count() == 0)
            {
                return NoContent();
            }
            return Ok(CategoryListDTO);

        }
       
      



    }
}