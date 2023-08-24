using Domain.Models;
using Infraestructure.Models;

namespace Infraestructure;

public static class Caster
{
    public static ParameterEntity ToEntity(this Parameter parameter)
    {
        return new()
        {
            Id = parameter.Id,
            Name = parameter.Name,
            Values = parameter.Values
        };
    }


    public static Parameter ToDomain(this ParameterEntity parameter)
    {
        return new()
        {
            Id = parameter.Id,
            Name = parameter.Name,
            Values = parameter.Values
        };
    }

    public static Parameter ToDomain(this ParameterDto parameter)
    {
        return new()
        {
            Name = parameter.Name,
            Values = parameter.Values
        };
    }
}