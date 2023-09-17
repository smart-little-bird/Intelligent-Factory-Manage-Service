using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string Province { get; }
    public string ZipCode { get; }

    private Address()
    {

    }

    public Address(string street, string city, string province, string zipcode) : this()
    {
        Street = street;
        City = city;
        Province = province;
        ZipCode = zipcode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return Province;
        yield return ZipCode;
    }

    public override string ToString()
    {
        return $"{Province} {City}{Street}";
    }
}