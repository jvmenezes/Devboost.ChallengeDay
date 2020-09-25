using Devboost.ChallengeDay.Data.Config;
using Devboost.ChallengeDay.Data.Contexts;
using Devboost.ChallengeDay.Data.Repositories;
using Devboost.ChallengeDay.Domain.Interfaces.Repositories;
using Devboost.ChallengeDay.Shared.Domain.Interfaces;
using Devboost.ChallengeDay.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace Devboost.ChallengeDay.IoC
{
    public static class ResolveDependencies
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {


            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            services.AddScoped(typeof(MongoDbContext<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IProducer, Producer>();

            MongoConfig.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoConfig.DatabaseName = configuration.GetSection("MongoConnection:Database").Value;
            MongoConfig.IsSSL = Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value);

            return services;
        }

    }
}
