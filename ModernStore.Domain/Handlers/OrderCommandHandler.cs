using ModernStore.Domain.CommandResults;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Interfaces;
using ModernStore.Domain.Primitives;
using ModernStore.Domain.Repositories;

namespace ModernStore.Domain.Handlers
{
    public class OrderCommandHandler : BaseEntity, ICommandHandler<CreateOrderCommand>
    {
        private List<CreateOrderItemCommand> _items;
        public IReadOnlyCollection<CreateOrderItemCommand> Products => _items;
       
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository,
                                   IProductRepository productRepository,
                                   IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _items = new List<CreateOrderItemCommand>();
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);

            var order = new Order(customer, command.DeliveryFee, command.Discount);
                

            foreach (var _items in command.Products)
            {
                var product = _productRepository.Get(_items.Product);
                order.AddItem(new OrderItem(product, _items.Qty));
            }

            if(IsValid())
                _orderRepository.Save(order);

            return new CreateOrderCommandResult
            {
                Number = order.Number
            };
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
