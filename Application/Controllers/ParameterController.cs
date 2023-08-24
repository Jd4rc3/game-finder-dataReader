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
    private readonly UpdateParameterValuesUseCase _updateParameterValuesUseCase;
    private readonly UpdateParameterNameUseCase _updateParameterNameUseCase;

    public ParameterController(CreateParameterUseCase createParameterUseCase, ReadParameterUseCase readParameterUseCase,
        UpdateParameterValuesUseCase updateParameterValuesUseCase, UpdateParameterNameUseCase updateParameterNameUseCase)
    {
        _createParameterUseCase = createParameterUseCase;
        _readParameterUseCase = readParameterUseCase;
        _updateParameterValuesUseCase = updateParameterValuesUseCase;
        _updateParameterNameUseCase = updateParameterNameUseCase;
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
        return _updateParameterValuesUseCase.UpdateParameter(parameter.ToDomain());
    }

    [HttpPatch("updatename/{oldName}/{newName}")]
    public Task<Parameter> UpdateName(string oldName, string newName)
    {
       return _updateParameterNameUseCase.UpdateParameterName(oldName, newName);
    }
}