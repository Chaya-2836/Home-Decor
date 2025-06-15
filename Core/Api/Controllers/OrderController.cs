using AutoMapper;
using Core.Dao;
using Core.Dto;
using Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
       
        public OrderController(IOrderService orderService, IMapper Mapper)
        {
            _orderService = orderService;
            _mapper = Mapper;
        }
        [HttpPost]
        public async Task<OrderDto> addOrderAsync(Core.Dto.OrderDto newOrder)
        {
            Order res = await _orderService.addOrderAsync(_mapper.Map<Order>(newOrder));
            return _mapper.Map<OrderDto>(res);
        }
       
    }
}
