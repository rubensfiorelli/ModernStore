using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;

var command = new CreateOrderCommand
{
    Customer = Guid.NewGuid(),
    DeliveryFee = 5.00m,
    Discount = 20.00m,
    Products = new List<CreateOrderItemCommand>
    {
        new CreateOrderItemCommand
        {
            Product = Guid.NewGuid(),
            Qty = 3
        }
    }

};
GenerateOrder(new FakeCustomerRepository(), new FakeProductRepository(), new FakeOrderRepository(), command);


static void GenerateOrder(ICustomerRepository customerRepository,
                          IProductRepository productRepository,
                          IOrderRepository orderRepository,
                          CreateOrderCommand command)
{

    var handler = new OrderCommandHandler(customerRepository, productRepository, orderRepository);

    handler.Handle(command);

    if (handler.IsValid())

        Console.WriteLine("Pedido criado");
        Console.ReadKey();


}




public class FakeCustomerRepository : ICustomerRepository
{
    public Customer Get(Guid id)
    {
        return null;
    }

    public Customer GetUserId(Guid id)
    {
        return new Customer(
            
            new Name("Rubens", "Fiorelli"), "rubens@test.com" , 
            new User("rubens", "rubens"), 
            new DeliveryAddress(100, "Rua das Flores","Sao Paulo", "SP", "05540020"));
    }
}

public class FakeProductRepository : IProductRepository
{
    public Product Get(Guid id)
    {
        return new Product("Mouse", 199.00m, 100);
    }
}

public class FakeOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {

    }
}



