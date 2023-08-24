using Domain.Models;
using Domain.UseCases;
using Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ParameterController : ControllerBase
{
    private readonly CreateParameterUseCase _createParameterUseCase;
    private readonly ReadParameterUseCase _readParameterUseCase;
    private readonly UpdateParameterUseCase _updateParameterUseCase;

    public ParameterController(CreateParameterUseCase createParameterUseCase, ReadParameterUseCase readParameterUseCase,
        UpdateParameterUseCase updateParameterUseCase)
    {
        _createParameterUseCase = createParameterUseCase;
        _readParameterUseCase = readParameterUseCase;
        _updateParameterUseCase = updateParameterUseCase;
    }

    [HttpGet]
    public Task<IEnumerable<Parameter>> GetAll()
    {
        return _readParameterUseCase.ReadAll();
    }

    [HttpPost]
    public Task Create(ParameterDto parameter)
    {
        return _createParameterUseCase.CreateParameter(parameter.ToDomain());
    }

    [HttpPut("updatevalues")]
    public Task<Parameter> UpdateParameter(ParameterDto parameter)
    {
        return _updateParameterUseCase.UpdateParameter(parameter.ToDomain());
    }
}