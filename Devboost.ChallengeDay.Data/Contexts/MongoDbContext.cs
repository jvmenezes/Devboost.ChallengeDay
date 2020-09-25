using Devboost.ChallengeDay.Data.Config;
using Devboost.ChallengeDay.Domain.Entities;
using MongoDB.Driver;

namespace Devboost.ChallengeDay.Data.Contexts
{
    public class MongoDbContext<TEntity> where TEntity : TransacaoModel
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConfig.ConnectionString));
            if (MongoConfig.IsSSL)
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(MongoConfig.DatabaseName);
        }

        public IMongoCollection<TEntity> Collection
        {
            get
            {
                return _database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }
    }
}
