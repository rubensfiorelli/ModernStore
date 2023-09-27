using ModernStore.Domain.Notifications;
using ModernStore.Domain.Validations.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernStore.Domain.Primitives
{
    public abstract class BaseEntity : IValidation
    {
        [NotMapped]
        private List<Notification> _notifications;

        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications => _notifications;


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            _notifications = new List<Notification>();
        }

        [Key]
        public Guid Id { get; protected init; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private DateTimeOffset _createdAt;

        public DateTimeOffset CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = DateTimeOffset.UtcNow; }
        }

        private DateTimeOffset? _updatedAt;

        public DateTimeOffset? UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }

        protected void AddNotification(List<Notification> notifications)
        {
            _notifications = notifications;
        }
        public abstract bool IsValid();
    }
}
