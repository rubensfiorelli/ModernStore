using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.Commands
{
    public class CreateOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Qty { get; set; }
    }
}
