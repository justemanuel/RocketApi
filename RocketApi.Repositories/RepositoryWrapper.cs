using RocketApi.Contracts;
using RocketApi.Entities;

namespace RocketApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RocketContext _context;

        private IOwnerRepository _owner;
        private IBlogRepository _blog;
        private IPostRepository _post;
        private IUserRepository _user;

        public RepositoryWrapper(RocketContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        // Singleton
        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_context);
                }

                return _owner;
            }
        }

        public IBlogRepository Blog
        {
            get
            {
                if (_blog == null)
                {
                    _blog = new BlogRepository(_context);
                }

                return _blog;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_context);
                }

                return _post;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }

                return _user;
            }
        }
    }
}
