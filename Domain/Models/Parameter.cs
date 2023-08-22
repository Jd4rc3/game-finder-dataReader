namespace Domain.Models
{
    public class Parameter
    {
        public string Id { get; set; }
    
        public string Name { get; set; }
    
        public IEnumerable<Store> Values { get; set; }
    }
}