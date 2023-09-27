using ModernStore.Domain.Entities;
using ModernStore.Domain.Queries;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListQuery> Get();
    }
}
