using ModernStore.Domain.Primitives;
using ModernStore.Domain.Validations;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {     
        private Customer() { }
        public Customer(Name name, string email, User user /*DeliveryAddress deliveryAddress*/) : base()
        {
            Name = name;
            BirthDate = null; ;
            Email = email;
            User = user;
            //DeliveryAddress = deliveryAddress;
        }

        public Name Name { get; private set; }
        public DateTimeOffset? BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        //public DeliveryAddress DeliveryAddress { get; private set; }


        public void SetupCustomer(Name name,/*, DeliveryAddress deliveryAdress, */DateTimeOffset? birthDate, string email)
        {
            BirthDate = birthDate;
            Email = email;
            Name = name;
            //DeliveryAddress = deliveryAdress;
        }

        public override bool IsValid()
        {
            var contracts = new ContractValidations<Customer>()
                .FirstNameIsOk(Name.FirstName, 15, "O primeiro nome precisa ser preenchido", nameof(Name.FirstName))
                .LastNameIsOk(Name.LastName, 50, "O sobrenome precisa ser preenchido", nameof(Name.LastName))
                .EmailIsOk(Email, "Informe um email válido", nameof(Email));
                //.DeliveryAddressIsOk(DeliveryAddress.Street, "Informe o endereco completo", nameof(DeliveryAddress));

            return  
                contracts.IsValid();

        }      


    }
}
