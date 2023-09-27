using ModernStore.Domain.Primitives;

namespace ModernStore.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        private Product() { }
        public Product(string title, decimal price, int qtyStock) : base()
        {
            Title = title;
            Price = price;
            QtyStock = qtyStock;
        }

        public string Title { get; private set; }
        public decimal Price { get; set; }
        public int QtyStock { get; private set; }


        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void DecreaseStock(int qty) => QtyStock -= qty;
    }
}
