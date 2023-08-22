
using Domain.Models;

namespace Domain.UseCases;

public class CreateParameterUseCase
{
    private readonly IParameterRepository _repository;

    public CreateParameterUseCase(IParameterRepository repository)
    {
        _repository = repository;
    }

    public Task CreateParameter(Parameter parameter)
    {
        return _repository.Create(parameter);
    }

    public Task<IEnumerable<Parameter>> ReadAll()
    {
        return _repository.GetAll();
    }

    public Task<Parameter> ReadByName(string name)
    {
        return _repository.GetByName(name);
    }
}