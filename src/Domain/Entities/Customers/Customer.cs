using Flux.Domain.Entities.Merchants;

namespace Flux.Domain.Entities.Customers
{
  public sealed class Customer : BaseEntity, IAggregateRoot
  {
     public Guid MerchantId { get; private set; } 
     public string Name { get; private set; }
     public string Surname { get; private set; }
     public string Email { get; private set; }
     public Address Address { get; private set; }
     public DateTime CreatedAt { get; private set; }
     public Merchant Merchant { get; private set; } 

     private Customer()
     {
         
     }

     private Customer(Guid merchantId, string name, string surname, string email, DateTime createdAt)
     {
        MerchantId = merchantId;
        Name = name;
        Surname = surname;
        Email = email;
        CreatedAt = createdAt;
     }

     // Instance of customer instance to create customer oustide this class
     public static Customer Create(Guid merchantId, string name, string surname, string email, DateTime createdAt)
     {
       return new Customer(merchantId, name, surname, email, createdAt);
     }

     public void UpdateAddress(Address address)
     {
       Address = address;
     }
  }
}
