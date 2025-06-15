using AutoMapper;
using Core;
using Core.Dto;
using Core.IService;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Service.DataService;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductInStock : ControllerBase
    {
        private readonly IProductInStockService _productInStockService;
        private readonly IMapper _mapper;
        public ProductInStock(IProductInStockService productInStockService, IMapper mapper)
        {
            _mapper = mapper;
            _productInStockService = productInStockService;
        }
        [HttpGet]
        [Route("GetByCategoryId/{id}")]
        public async Task<ActionResult<List<CategoryDto>>> GetByCategoryId(int id)
        {
            var products = await _productInStockService.getByCategoryId(id);
            return Ok(_mapper.Map<List<ProductInStockDto>>(products));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductInStockDto> GetById(int id)
        {
            var p = await _productInStockService.getById(id);
            return _mapper.Map<ProductInStockDto>(p);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<List<ProductInStockDto>>> GetFiltered(
     [FromQuery] int categoryId,
     [FromQuery] double? minPrice,
     [FromQuery] double? maxPrice,
     [FromQuery] List<productTypes>? types)
        {
            var result = await _productInStockService.GetFilteredAsync(categoryId, minPrice, maxPrice, types);
            return Ok(result);
        }


    }
}
