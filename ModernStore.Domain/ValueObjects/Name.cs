namespace ModernStore.Domain.ValueObjects
{
    public class Name : BaseValueObject
    {
        private Name() { }
        public Name(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
