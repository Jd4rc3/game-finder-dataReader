using Domain.Models;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ParameterController : ControllerBase
{
    private readonly CreateParameterUseCase _createParameterUseCase;
    private readonly ReadParameterUseCase _readParameterUseCase;

    public ParameterController(CreateParameterUseCase createParameterUseCase, ReadParameterUseCase readParameterUseCase)
    {
        _createParameterUseCase = createParameterUseCase;
        _readParameterUseCase = readParameterUseCase;
    }

    [HttpGet]
    public Task<IEnumerable<Parameter>> GetAll()
    {
        return _readParameterUseCase.ReadAll();
    }

    [HttpPost]
    public Task Create(Parameter parameter)
    {
       return _createParameterUseCase.CreateParameter(parameter);
    }
}
