using AsaniSample.Core.Entities;
using AsaniSample.Infrastructure.Data.Repository.IRepository;

namespace AsaniSample.Infrastructure.Data.Repository
{
   public class EstateRepository :Repository<Estate>,IEstateRepository
    {
        public EstateRepository(AsaniSampleContext context) : base(context)
        {
        }
    }
}
