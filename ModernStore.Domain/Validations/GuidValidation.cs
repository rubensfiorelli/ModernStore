using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> IsGUID(object guid, string message, string propertyName)
        {
            if (guid is not Guid)

                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
