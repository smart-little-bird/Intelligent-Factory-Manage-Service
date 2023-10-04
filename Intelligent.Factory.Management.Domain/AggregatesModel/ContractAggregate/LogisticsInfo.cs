using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public class LogisticsInfo:ValueObject
{
    private LogisticsInfo(){}
    public LogisticsInfo(DateTime shipDateTime, string shipType, string logisticsUndertaker):this()
    {
        ShipDateTime = shipDateTime;
        ShipType = shipType;
        LogisticsUndertaker = logisticsUndertaker;
    }
    
    public DateTime ShipDateTime { get;private set; }

    public string ShipType { get;private set; }

    public string LogisticsUndertaker { get;private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ShipDateTime;
        yield return ShipType;
        yield return LogisticsUndertaker;
    }
}