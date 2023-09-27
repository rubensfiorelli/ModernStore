using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModernStore.Data.DataContext;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Queries;
using ModernStore.Domain.Repositories;

namespace ModernStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<GetProductListQuery> Get()
        {
            using var conn = new SqlConnection(@"Server=localhost,1433;Database=ModernStoreCQRS;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True");
            
            conn.Open();
            
            return conn.Query<GetProductListQuery>("SELECT [Id], [Title], [Price] FROM [Product]");
        }
    }
}
