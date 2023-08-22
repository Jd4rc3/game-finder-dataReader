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
}