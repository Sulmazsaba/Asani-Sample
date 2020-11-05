using AsaniSample.Infrastructure.Data.Repository.IRepository;

namespace AsaniSample.Infrastructure.Data.Repository
{
  public  class UnitOfWork : IUnitOfWork
  {
      private readonly AsaniSampleContext context;

      public UnitOfWork(AsaniSampleContext context)
      {
          this.context = context;
          EstateRepository=new EstateRepository(context);
      }

      public void Dispose()
        {
           context.Dispose();
        }

        public IEstateRepository EstateRepository { get; private set; }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
