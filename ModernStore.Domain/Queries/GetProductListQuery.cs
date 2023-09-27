using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.Queries
{
    public sealed class GetProductListQuery : IQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}
