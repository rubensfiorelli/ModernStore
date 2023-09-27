using ModernStore.Domain.Notifications;

namespace ModernStore.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        private readonly List<Notification> _notifications;

        public ContractValidations()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool IsValid()
        {
            return _notifications.Any();
           // return _notifications.Count == 0;

        }
    }
}
