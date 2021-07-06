using Microsoft.EntityFrameworkCore;
using RocketApi.Contracts;
using RocketApi.Entities;
using RocketApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketApi.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RocketContext context)
            :base(context)
        {

        }

        public void AddFollowee(User user, User userToFollow)
        {
            var item = new Follow()
            {
                FolloweeId = userToFollow.Id,
                Followee = userToFollow,
                Follower = user,
                FollowerId = user.Id
            };

            user.Followee.Add(item);
            _context.Users.Update(user);
        }

        public void AddStatus(User user, string content)
        {
            user.Status.Add(new Status()
            {
                Content = content
            });
        }

        public async Task<User> FindUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<Status>> GetFolloweesStatuses(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id)
                .Include(x => x.Followee)
                .FirstOrDefaultAsync();

            var ids = user.Followee.Select(x => x.FolloweeId).ToList();

            return await _context.Status.Where(x => ids.Contains(x.UserId))
                .OrderByDescending(x => x.Created)
                .ToListAsync();
        }
    }
}
