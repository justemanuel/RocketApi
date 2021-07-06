﻿namespace RocketApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IBlogRepository Blog { get; }
        IPostRepository Post { get; }

        void Save();
    }
}
