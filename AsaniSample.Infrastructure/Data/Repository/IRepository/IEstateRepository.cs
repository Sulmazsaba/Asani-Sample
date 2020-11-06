using System;
using AsaniSample.Core.Entities;

namespace AsaniSample.Infrastructure.Data.Repository.IRepository
{
  public  interface IEstateRepository  : IRepository<Estate>
  {
      void AddEstate(Estate estate);

      Estate GetEstate(Guid id);

      void RemoveLogicalEstate(Estate estate);
  }
}
