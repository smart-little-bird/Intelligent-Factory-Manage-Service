using Intelligent.Factory.Management.Domain.SeedWork;

namespace Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;

public interface IContractRepository : IRepository<Contract>
{
    Task<Contract?> GetAsync(int id);

    Contract? Add(Contract? contract);

    Contract? Update(Contract? contract);

    Task<List<Contract>> GetListWithPageAsync(int pageIndex, int pageSize);

    Task<int> GetAccount();
}