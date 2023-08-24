using Domain.Models;

namespace Domain.UseCases;

public class DeleteParameterUseCase
{
    private readonly IParameterRepository _repository;

    public DeleteParameterUseCase(IParameterRepository repository)
    {
        _repository = repository;
    }

    public Task<Parameter> Delete(string name)
    {
       return _repository.Delete(name);
    }
}