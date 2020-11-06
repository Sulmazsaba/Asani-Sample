using System;

namespace AsaniSample.Infrastructure.Data.Repository.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        IEstateRepository EstateRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        void Commit();

    }
}
