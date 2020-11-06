using System;
using System.Linq;
using AsaniSample.Core.Entities;
using AsaniSample.Infrastructure.Data.Repository.IRepository;

namespace AsaniSample.Infrastructure.Data.Repository
{
   public class EstateRepository :Repository<Estate>,IEstateRepository
    {
        public EstateRepository(AsaniSampleContext context) : base(context)
        {
        }

        public void AddEstate(Estate estate)
        {
            if(estate==null)
                throw new ArgumentNullException(nameof(estate));
            estate.Id=Guid.NewGuid();
            context.Estates.Add(estate);
        }

        public Estate GetEstate(Guid id)
        {
            if(id==Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return context.Estates.FirstOrDefault(i => !i.IsDeleted && i.Id == id);
        }

        public void RemoveLogicalEstate(Estate estate)
        {
            estate.IsDeleted = true;
        }
    }
}
