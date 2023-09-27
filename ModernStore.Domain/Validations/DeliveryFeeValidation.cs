using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> DeliveryFeeIsOk(decimal fee, string message, string propertyName)
        {
            if (fee <= 0)
                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
