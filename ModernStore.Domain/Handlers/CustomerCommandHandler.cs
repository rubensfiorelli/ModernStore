using ModernStore.Domain.CommandResults;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Interfaces;
using ModernStore.Domain.Notifications;
using ModernStore.Domain.Primitives;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Handlers
{
    public class CustomerCommandHandler : BaseEntity, ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
       
        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Verifica se Email ja existe
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_customerRepository.EmailExists(command.Email))
            {
                AddNotification((List<Notification>)command.Notifications);
                return null;

            }

            //Gerar novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var user = new User(command.Username, command.PasswordHash, command.ConfirmPassword);

            var customer = new Customer(name, command.Email, user);

            // Persistir no Banco
            if (IsValid())
                _customerRepository.Save(customer);

            // Enviar a senha do User de boas vindas


            // retornar algo

            return new CreateCustomerCommandResult(customer.Id, customer.Name.FirstName.ToString());

        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
