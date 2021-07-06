using RocketApi.Contracts;
using RocketApi.Entities;
using RocketApi.Entities.Models;

namespace RocketApi.Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RocketContext context)
            : base(context)
        {
        }
    }
}
