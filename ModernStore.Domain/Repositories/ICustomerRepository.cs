using ModernStore.Domain.Entities;
using ModernStore.Domain.Queries;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        GetCustomerQuery Get(string email);
        Customer GetUserId(Guid id);
        bool EmailExists(string email);
        void Save(Customer customer);
    }
}
