using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> DeliveryAddressIsOk(string deliveryAddress, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(deliveryAddress))

                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
