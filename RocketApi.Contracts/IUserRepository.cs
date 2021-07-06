using RocketApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketApi.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void AddFollowee(User actualUser, User newFollowee);

        Task<User> FindUserById(int id);

        void AddStatus(User user, string content);

        Task<IEnumerable<Status>> GetFolloweesStatuses(int id);
    }
}
