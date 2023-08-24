using Domain.Models;

namespace Domain.UseCases;

public class UpdateParameterNameUseCase
{
    private readonly IParameterRepository _repository;

    public UpdateParameterNameUseCase(IParameterRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Parameter> UpdateParameterName(string oldName,string newName)
    {
        return _repository.UpdateName(oldName,newName);
    }
}