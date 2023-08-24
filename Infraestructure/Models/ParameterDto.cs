using Domain.Models;

namespace Infraestructure.Models;

public class ParameterDto
{
    public string Name { get; set; }
    
    public IEnumerable<Store> Values { get; set; }
}