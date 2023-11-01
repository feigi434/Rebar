using Rebar.Models;
using MongoDB.Driver;

namespace Rebar.Services
{
    public class ShakeService : IShakeService
    {
        private readonly IMongoCollection<Shake> _shakes;

        public ShakeService(IRebarStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _shakes = database.GetCollection<Shake>(settings.ShakeCollectionName);
        }

        Shake IShakeService.Create(Shake shake)
        {
            _shakes.InsertOne(shake);
            return shake;
        }

        List<Shake> IShakeService.Get()
        {
            return _shakes.Find(shake => true).ToList();
        }

        Shake IShakeService.Get(Guid id)
        {
            return _shakes.Find(shake => shake.Id == id).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            _shakes.DeleteOne(shake => shake.Id == id);
        }

        void IShakeService.Update(Guid id, Shake shake)
        {
            _shakes.ReplaceOne(shake => shake.Id == id, shake);
        }
    }
}
