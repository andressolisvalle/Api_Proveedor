using Domain.Ports;
using Infrastructure.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Persistence;

public static class PersistenceExtension
{
    public static IServiceCollection AddPesistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IMongoDatabase>((sp) =>
        {

            var client = new MongoClient(config.GetConnectionString("database"));
            return client.GetDatabase(config.GetConnectionString("databaseName"));

        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}