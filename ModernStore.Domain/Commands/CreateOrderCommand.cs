using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public required IEnumerable<CreateOrderItemCommand> Products { get; set; }
    }
}
