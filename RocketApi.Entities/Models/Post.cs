using System;

namespace RocketApi.Entities.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public DateTime Posted { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
