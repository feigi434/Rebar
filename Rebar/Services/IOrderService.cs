using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {
        List<Order> Get();
        Order Get(Guid id);
        Order Create(Order order);
        void Update(Guid id, Order order);
        void Remove(Guid id);
    }
}
