using ModernStore.Domain.Interfaces;

namespace ModernStore.Domain.CommandResults
{
    public class CreateOrderCommandResult : ICommandResult
    {
        public required string Number { get; set; }

    }
}
