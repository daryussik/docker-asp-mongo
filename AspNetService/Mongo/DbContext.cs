using AspNetService.Models;
using MongoDB.Driver;

namespace AspNetService.Mongo
{
    public interface IDbContext
    {
        IMongoCollection<MessageDataModel> Messages { get; }
    }

    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _db;

        public DbContext(IMongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<MessageDataModel> Messages => _db.GetCollection<MessageDataModel>("Messages");
    }
}