using ModernStore.Domain.Primitives;
using ModernStore.Domain.Validations;

namespace ModernStore.Domain.Entities
{
    public sealed class OrderItem : BaseEntity
    {
        private OrderItem() { }
        public OrderItem(Product product, int qty) : base()
        {
            Product = product;
            Qty = qty;
            Price = Product.Price;

            Product.DecreaseStock(qty);
        }

        public Product Product { get; private set; }
        public int Qty { get; private set; }
        public decimal Price { get; private set; }


        public decimal TotalPrice() => Price * Qty;


        public override bool IsValid()
        {
            var contracts = new ContractValidations<OrderItem>()
                .QtyIsOk(0, "O valor nao pode ser menor que zero", nameof(Qty))
                .StockIsOk(10 + 1, "O pedido deve ser menor que o estoque disponivel", nameof(Qty));

            return
                contracts.IsValid();
        }     
    }
}