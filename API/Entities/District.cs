using System.Collections.Generic;

namespace API.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; }
        
    }
}