using Domain.Models;

namespace Domain.UseCases;

public interface IParameterRepository
{
    Task Create(Parameter parameter);

    Task<IEnumerable<Parameter>> GetAll();

    Task<Parameter> GetByName(string name);

    Task<Parameter> UpdateValues(Parameter parameter);
}