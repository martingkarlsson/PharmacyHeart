using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyOrderApi.Models;
using PharmacyOrderApi.Models.Dtos;
using PharmacyOrderApi.Repositories;

namespace PharmacyOrderApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<List<OrderDto>> GetAllOrders()
        {          
            return await _orderRepository.GetAllOrders(); 
        }

        [HttpGet]
        [Route("GetOrder/{customerId:int}")]
        public async Task<IActionResult> GetOrderByCustomerId(int customerId)
        {
            OrderDto orderDto =  await _orderRepository.GetOrderByCustomerId(customerId);
            if (orderDto == null) return NotFound();
            return Ok(orderDto); 
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            OrderDto order = await _orderRepository.CreateOrder(orderDto);
            if (order == null) return BadRequest();
            return Ok(order);
        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto orderDto)
        {
            OrderDto order = await _orderRepository.UpdateOrder(orderDto);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _orderRepository.DeleteOrder(orderId);

            return NoContent(); 
        }
    }
}
