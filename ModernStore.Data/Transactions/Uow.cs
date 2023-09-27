using ModernStore.Data.DataContext;

namespace ModernStore.Data.Transactions
{
    public sealed class Uow : IUow
    {
        private readonly ModernStoreDataContext _context;

        public Uow(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
           // Do nothing
        }
    }
}
