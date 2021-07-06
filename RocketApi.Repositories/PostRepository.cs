using RocketApi.Contracts;
using RocketApi.Entities;
using RocketApi.Entities.Models;

namespace RocketApi.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RocketContext context)
            : base(context)
        {

        }
    }
}
