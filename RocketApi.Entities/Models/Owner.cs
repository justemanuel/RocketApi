using System.Collections.Generic;

namespace RocketApi.Entities.Models
{
    public class Owner : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
