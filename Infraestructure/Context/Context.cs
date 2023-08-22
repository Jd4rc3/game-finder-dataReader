using Infraestructure.Models;
using MongoDB.Driver;

namespace Infraestructure.Context;

public class Context : IContext
{
    private readonly IMongoDatabase _database;
    public IMongoCollection<ParameterEntity> Parameters => _database.GetCollection<ParameterEntity>("parameters");

    public Context(string conexion, string name)
    {
        var mongoClient = new MongoClient(conexion);
        _database = mongoClient.GetDatabase(name);
    }
}

public interface IContext
{
    IMongoCollection<ParameterEntity> Parameters { get; }
}