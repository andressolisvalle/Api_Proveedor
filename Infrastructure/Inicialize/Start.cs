using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicialize;


public class Start
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<User> _collection;

    public Start(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("database"));
        _database = client.GetDatabase(config.GetConnectionString("databaseName"));
        _collection = _database.GetCollection<User>("User");
    }

    //public void seeds()
    //{
    //    if (!_collection.AsQueryable().Any())
    //    {
    //        var user = new User("admin", "12345678");

    //        _collection.InsertOne(user);
    //    }
    //}
}