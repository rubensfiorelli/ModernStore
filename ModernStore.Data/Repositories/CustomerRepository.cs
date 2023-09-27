using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModernStore.Data.DataContext;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Queries;
using ModernStore.Domain.Repositories;

namespace ModernStore.Data.Repositories
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool EmailExists(string email)
        {
            return _context.Customers.Any(x => x.Email.Equals(email));
        }

        public Customer Get(Guid id)
        {
           return _context.Customers.Include(x => x.User).AsTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public GetCustomerQuery Get(string email)
        {

            // Retorno com o Entity
            //return _context
            //    .Customers
            //    .Include(x => x.User)
            //    .Select(x => new GetCustomerQuery
            //    { 
            //        Name = x.Name.ToString(),
            //        Email = x.Email,
            //        Username = x.User.Username,
            //        Password = x.User.PasswordHash,
            //        Active = x.User.Active                
            //    }).FirstOrDefault(x => x.Email == email);

            using var conn = new SqlConnection(@"Server=localhost,1433;Database=ModernStoreCQRS;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True");
            conn.Open();
            return conn.Query<GetCustomerQuery>("SELECT * FROM [Customer] WHERE [Active] = 1 AND [Email]=@email", new { email }).FirstOrDefault();


        }

        public Customer GetUserId(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
           
        }

        //public void Update(Customer customer)
        //_context.Entry(customer).State = EntityState.Modified;
    }
}
