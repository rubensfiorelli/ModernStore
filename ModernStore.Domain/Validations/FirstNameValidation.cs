using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> FirstNameIsOk(string firstName, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(firstName) || (firstName.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
