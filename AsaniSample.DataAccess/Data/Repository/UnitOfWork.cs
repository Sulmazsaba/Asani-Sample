using AsaniSample.DataAccess.Data.Repository.IRepository;

namespace AsaniSample.DataAccess.Data.Repository
{
  public  class UnitOfWork : IUnitOfWork
  {
      private readonly AsaniSampleContext context;

      public UnitOfWork(AsaniSampleContext context)
      {
          this.context = context;
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
