namespace ModernStore.Data.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    
    }
}
