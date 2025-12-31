namespace Flux.Domain.Entities.Customers
{
  public record Address : IValueObject
  {
    public string Street { get; init; }
    public string Suburb { get; init; }
    public string City { get; init; }
    public string Province { get; init; }
    public string Country { get; init; }
    public string ZipCode { get; init; }

    public Address(string street, string suburb, string city, string province, string country, string zipcode)
    {
      Street = street;
      Suburb = suburb;
      City = city;
      Province = province;
      Country = country;
      ZipCode = zipcode;
    }

    // Factory method: We can add businees rules to this or validation
    public static Address Create(string street, string suburb, string city, string province, string country, string zipcode)
    {
      if (string.IsNullOrEmpty(zipcode)) return null!;
      return new Address(street, suburb, city, province, country, zipcode);
    }
  }
}
