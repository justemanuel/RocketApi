using System;
using System.Collections.Generic;

namespace RocketApi.Entities.Models
{
    public class Blog : Entity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
