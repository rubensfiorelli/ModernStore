using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.Queries
{
    public sealed class GetCustomerQuery : IQuery
    {
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
