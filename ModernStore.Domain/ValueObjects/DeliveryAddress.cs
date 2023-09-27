namespace ModernStore.Domain.ValueObjects
{
    public class DeliveryAddress : BaseValueObject
    {
        private DeliveryAddress() { }
        public DeliveryAddress(int number,
                               string street,
                               string city,
                               string state,
                               string zipCode) : base()
        {
            Number = number;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int Number { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }



        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Number;
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
