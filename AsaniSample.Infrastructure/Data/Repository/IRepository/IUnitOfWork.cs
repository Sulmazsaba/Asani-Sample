using System;

namespace AsaniSample.Infrastructure.Data.Repository.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        IEstateRepository EstateRepository { get; }

        void Commit();

    }
}
