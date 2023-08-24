using Domain.Models;

namespace Domain.UseCases;

public class UpdateParameterValuesUseCase
{
    private readonly IParameterRepository _repository;

    public UpdateParameterValuesUseCase(IParameterRepository repository)
    {
        _repository = repository;
    }

    public Task<Parameter> UpdateParameter(Parameter parameter)
    {
        return _repository.UpdateValues(parameter);
    }
}