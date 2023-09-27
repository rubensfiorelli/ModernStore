using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.CommandResults
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
