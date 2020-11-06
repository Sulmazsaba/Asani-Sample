using AsaniSample.Infrastructure.Data.Repository.IRepository;

namespace AsaniSample.Infrastructure.Data.Repository
{
  public  class UnitOfWork : IUnitOfWork
  {
      private readonly AsaniSampleContext context;
      private IEstateRepository _estateRepository;
      private IOwnerRepository _ownerRepository;

      public UnitOfWork(AsaniSampleContext context)
      {
          this.context = context;
      }


      public IEstateRepository EstateRepository => _estateRepository ?? new EstateRepository(context);
      public IOwnerRepository OwnerRepository => _ownerRepository ?? new OwnerRepository(context);

        public void Commit()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
           context.Dispose();
        }
    }
}
