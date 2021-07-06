using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketApi.Entities.Models
{
    public class Follow
    {
        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }
        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
