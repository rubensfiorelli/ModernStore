using ModernStore.Domain.Enums;
using ModernStore.Domain.Primitives;
using ModernStore.Domain.Validations;

namespace ModernStore.Domain.Entities
{
    public sealed class Order : AggregateRoot
    {
        private Order() { }
        public Order(Customer customer,
                     decimal deliveryFee,
                     decimal discount) : base()
        {
            Customer = customer;
            DateOrder = DateTimeOffset.UtcNow;
            Number = Guid.NewGuid().ToString()[..8].Normalize();
            Status = EOrderStatus.Started;
            DeliveryFee = deliveryFee;
            Discount = discount;

            _items = new List<OrderItem>();
        }

        public Customer Customer { get; private set; }
        public DateTimeOffset DateOrder { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }


        public decimal SubTotal() => Items.Sum(x => x.TotalPrice());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;


        private List<OrderItem> _items;
        public void AddItem(OrderItem item)
        {
            AddNotification((List<Notifications.Notification>)item.Notifications);
            
            if(item.IsValid())
                _items.Add(item);

        }
      
        public override bool IsValid()
        {
            var contracts = new ContractValidations<Order>()
               .DeliveryFeeIsOk(0, "A taxa de entrega nao pode ser negativa", nameof(DeliveryFee));              

            return
                contracts.IsValid();
        }

       
    }
}
