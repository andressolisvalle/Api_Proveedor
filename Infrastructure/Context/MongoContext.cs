using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class MongoContext<T>
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("database"));
            _database = client.GetDatabase(config.GetConnectionString("databaseName"));

        }
        public IMongoCollection<T> DataBase => _database.GetCollection<T>(typeof(T).Name);
    }
}
