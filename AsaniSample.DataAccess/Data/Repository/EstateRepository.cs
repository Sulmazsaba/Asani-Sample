using AsaniSample.DataAccess.Data.Repository.IRepository;
using AsaniSample.Models;

namespace AsaniSample.DataAccess.Data.Repository
{
   public class EstateRepository :Repository<Estate>,IEstateRepository
    {
        public EstateRepository(AsaniSampleContext context) : base(context)
        {
        }
    }
}
