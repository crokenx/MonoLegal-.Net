using ApiNetCoreMonoLegal.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ApiNetCoreMonoLegal.Services
{
    public class BillsService
    {
        private readonly IMongoCollection<Bills> _bills;

        public BillsService(IBillsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bills = database.GetCollection<Bills>(settings.BillsCollectionName);
        }

        public List<Bills> Get() =>
            _bills.Find(bill => true).ToList();

        public Bills Get(string id) =>
            _bills.Find<Bills>(bill => bill._id == id).FirstOrDefault();

        public void Update(string id, Bills billIn) =>
            _bills.ReplaceOne(bill => bill._id == id, billIn);
    }
}
