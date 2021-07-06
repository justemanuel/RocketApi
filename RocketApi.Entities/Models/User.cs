using System.Collections.Generic;

namespace RocketApi.Entities.Models
{
    public class User : Entity
    {
        public User()
        {
            Follower = new HashSet<Follow>();
            Followee = new HashSet<Follow>();
            Status = new HashSet<Status>();
        }

        public string ScreenName { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Follow> Follower { get; set; }

        public ICollection<Follow> Followee { get; set; }

        public ICollection<Status> Status { get; set; }
    }
}
