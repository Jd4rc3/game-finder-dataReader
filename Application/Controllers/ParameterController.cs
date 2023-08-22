using Domain.Models;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ParameterController : ControllerBase
{
    private readonly CreateParameterUseCase _useCase;

    public ParameterController(CreateParameterUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public async Task<IEnumerable<Parameter>> GetAll()
    {
        return await _useCase.ReadAll();
    }
}
