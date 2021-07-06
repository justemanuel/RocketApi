namespace RocketApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IBlogRepository Blog { get; }
        IPostRepository Post { get; }
        IUserRepository User { get; }

        void Save();
    }
}
