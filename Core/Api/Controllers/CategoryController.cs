using AutoMapper;
using Core.Dao;
using Core.Dto;
using Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryService _categoryService;
       private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetByDepartmentId/{id}")]
        public async Task<ActionResult<List<CategoryDto>>> GetByDepartmentId(int id)
        {
            var categories = await _categoryService.GetAllCategoriesByDepartmentId(id);
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<CategoryDto> GetById(int id)
        {
            return _mapper.Map<CategoryDto>(await _categoryService.GetById(id));
        }




        
    }
}
