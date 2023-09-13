using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;

public class ClientAgent:Entity
{
    public ClientAgent()
    {
    }

    public ClientAgent(string name, string phoneNumber):this()
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }
}