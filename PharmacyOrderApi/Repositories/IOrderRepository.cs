using PharmacyOrderApi.Models;
using PharmacyOrderApi.Models.Dtos;

namespace PharmacyOrderApi.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrderByCustomerId(int customerId);
        Task<OrderDto> CreateOrder(OrderDto orderDto);
        Task<OrderDto> UpdateOrder(OrderDto orderDto);
        Task<bool> DeleteOrder(int orderId);
    }
}
