using AutoMapper;
using Core.Dto;
using Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        
        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetAll()
        {
            var Departments = await _departmentService.GetAll();
            return Ok(_mapper.Map<List<DepartmentDto>>(Departments));
        }
    }
}
