using RocketApi.Contracts;
using RocketApi.Entities;
using RocketApi.Entities.Models;

namespace RocketApi.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RocketContext context)
            : base(context)
        {
        }


    }
}
