using MediatR;

namespace Intelligent.Factory.Management.API.Applications.Commands;

public class CreateOrderCommand: IRequest<int>
{
    public CreateOrderCommand(string orderName, string clientId, DateTime shipDateTime)
    {
        OrderName = orderName;
        ClientId = clientId;
        ShipDateTime = shipDateTime;
    }

    public string OrderName { get;  }

    public string ClientId { get;  }

    public DateTime ShipDateTime { get; set; }
    
}