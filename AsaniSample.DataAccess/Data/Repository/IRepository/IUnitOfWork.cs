using System;

namespace AsaniSample.DataAccess.Data.Repository.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        IEstateRepository EstateRepository { get; }

        void Commit();

    }
}
