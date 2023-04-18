using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PharmacyOrderApi.Data;
using PharmacyOrderApi.Models;
using PharmacyOrderApi.Models.Dtos;
using System;

namespace PharmacyOrderApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(OrderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders =  await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByCustomerId(int customerId)
        {
            Order order =  await _dbContext.Orders
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .FirstOrDefaultAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            if (order != null && order.OrderId > 0)
            {
                _dbContext.Orders.Update(order);
            }
            
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            Order orderFromDb = await _dbContext.Orders.FindAsync(orderId);
            if (orderFromDb == null) return false;

            _dbContext.Orders.Remove(orderFromDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
