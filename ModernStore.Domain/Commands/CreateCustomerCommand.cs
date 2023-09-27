using ModernStore.Domain.Interfaces;
using ModernStore.Domain.Primitives;

namespace ModernStore.Domain.Commands
{
    public class CreateCustomerCommand : BaseEntity, ICommand
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int Number { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string ConfirmPassword { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}