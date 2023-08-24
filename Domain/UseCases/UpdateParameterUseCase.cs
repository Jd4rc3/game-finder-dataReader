using Domain.Models;

namespace Domain.UseCases;

public class UpdateParameterUseCase
{
    private readonly IParameterRepository _repository;

    public UpdateParameterUseCase(IParameterRepository repository)
    {
        _repository = repository;
    }

    public Task<Parameter> UpdateParameter(Parameter parameter)
    {
        return _repository.UpdateValues(parameter);
    }
}