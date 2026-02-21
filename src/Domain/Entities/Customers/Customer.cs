using Flux.Domain.Entities.Merchants;
using SharedKernal;

namespace Flux.Domain.Entities.Customers
{
    public sealed class Customer : BaseEntity, IAggregateRoot
    {
        public Guid MerchantId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Surname { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public Address Address { get; private set; }
        public Merchant Merchant { get; private set; }

        private Customer() { }

        private Customer(Guid merchantId, string name, string surname, string email)
        {
            MerchantId = merchantId;
            Name = name;
            Surname = surname;
            Email = email;
        }

        // Instance of customer instance to create customer oustide this class
        public static Customer Create(Guid merchantId, string name, string surname, string email)
        {
            return new Customer(merchantId, name, surname, email);
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
