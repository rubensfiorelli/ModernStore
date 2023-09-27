using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> LastNameIsOk(string lastName, short maxLenght, string message, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(lastName) || (lastName.Length > maxLenght))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
