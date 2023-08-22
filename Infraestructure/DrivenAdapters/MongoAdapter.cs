using Domain.Models;
using Domain.UseCases;
using Infraestructure.Context;
using Infraestructure.Models;
using MongoDB.Driver;

namespace Infraestructure.DrivenAdapters;

public class MongoAdapter : IParameterRepository
{
    private readonly IContext _context;

    public MongoAdapter(IContext context)
    {
        _context = context;
    }

    public async Task Create(Parameter parameter)
    {
        await _context.Parameters.InsertOneAsync(parameter.ToEntity());
    }

    public async Task<IEnumerable<Parameter>> GetAll()
    {
        return (await _context.Parameters.FindAsync(_ => true)).ToList().Select(x => x.ToDomain());
    }

    public Task<Parameter> GetByName(string name)
    {
        return _context.Parameters.Find(x => x.Name.Equals(name)).FirstOrDefaultAsync()
            .ContinueWith(x => x.Result.ToDomain());
    }

    public async Task<Parameter> Update(Parameter parameter)
    {
        var updateDefinition = Builders<ParameterEntity>.Update.Set(param => param.Values, parameter.Values);

        var result =
            await _context.Parameters.FindOneAndUpdateAsync(param => param.Name.Equals(parameter.Name),
                updateDefinition);

        return result.ToDomain();
    }
}