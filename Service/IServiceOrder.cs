using Entite;

namespace Service
{
    public interface IServiceOrder
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderbyId(int id);
    }
}