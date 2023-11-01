using Rebar.Models;
using MongoDB.Driver;

namespace Rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrderCollectionName);
        }

        Order IOrderService.Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }

        List<Order> IOrderService.Get()
        {
            return _orders.Find(order => true).ToList();
        }

        Order IOrderService.Get(Guid id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();
        }

        void IOrderService.Remove(Guid id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }

        void IOrderService.Update(Guid id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);
        }

        
    }
}
