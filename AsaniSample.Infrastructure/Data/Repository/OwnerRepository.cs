using System;
using System.Collections.Generic;
using System.Text;
using AsaniSample.Core.Entities;
using AsaniSample.Infrastructure.Data.Repository.IRepository;

namespace AsaniSample.Infrastructure.Data.Repository
{
   public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(AsaniSampleContext context) : base(context)
        {
        }
    }
}
