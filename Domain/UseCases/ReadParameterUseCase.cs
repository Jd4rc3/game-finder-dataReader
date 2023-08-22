using Domain.Models;

namespace Domain.UseCases;

public class ReadParameterUseCase
{
    private readonly IParameterRepository _repository;

    public ReadParameterUseCase(IParameterRepository repository)
    {
        _repository = repository;
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