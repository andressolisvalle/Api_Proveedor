using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Persistence;

public static class MongoContextExtensions
{
    public static IServiceCollection AddMongoContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(typeof(MongoContext<>));
        return services;
    }
}
