using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> StockIsOk(int qty, string message, string propertyName)
        {

            if (qty <= 10)
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
