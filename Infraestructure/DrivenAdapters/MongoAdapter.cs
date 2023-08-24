using System.Net;
using Domain.Models;
using Domain.UseCases;
using Infraestructure.Context;
using Infraestructure.Exceptions;
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

    public async Task<Parameter> GetByName(string name)
    {
        var result = await _context.Parameters.Find(x => x.Name.Equals(name)).FirstOrDefaultAsync();

        CheckNotFound(name, result);

        return result.ToDomain();
    }

    public async Task<Parameter> UpdateValues(Parameter parameter)
    {
        var updateDefinition = Builders<ParameterEntity>.Update.Set((param) => param.Values, parameter.Values);

        var document =
            await _context.Parameters.FindOneAndUpdateAsync(param => param.Name.Equals(parameter.Name),
                updateDefinition);

        CheckNotFound(parameter.Name, document);

        var result = document.ToDomain();
        result.Values = parameter.Values;

        return result;
    }


    public async Task<Parameter> UpdateName(string oldName, string newName)
    {
        var updateDefinition = Builders<ParameterEntity>.Update.Set((param) => param.Name, newName);

        var document =
            await _context.Parameters.FindOneAndUpdateAsync(param => param.Name.Equals(oldName), updateDefinition);

        CheckNotFound(oldName, document);

        var result = document.ToDomain();
        result.Name = newName;

        return result;
    }

    public async Task<Parameter> Delete(string name)
    {
        var result = await _context.Parameters.FindOneAndDeleteAsync(param => param.Name.Equals(name));

        CheckNotFound(name, result);

        return result.ToDomain();
    }


    private static void CheckNotFound(string searchValue, ParameterEntity result)
    {
        if (result == null)
        {
            throw new BusinessException($"Parameter with name \'{searchValue}\' not found",
                HttpStatusCode.NotFound);
        }
    }
}