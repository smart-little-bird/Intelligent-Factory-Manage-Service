using Dapper;

using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Microsoft.Data.SqlClient;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ClientQueries : IClientQueries
{
    private string _connectionString = string.Empty;

    public ClientQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr)
            ? constr
            : throw new ArgumentNullException(nameof(constr));
    }

    public async IAsyncEnumerable<ClientListDto> GetClientListAsync(int pageIndex, int pageSize)
    {
        await using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var result = await connection.QueryAsync<dynamic>(
                sql:
                "SELECT * FROM (SELECT Product.[Id],Product.[ProductStatusId],[CreateTime],[Description],(DemanSide.[Province]+DemanSide.[City]+DemanSide.[Street]) as AddressDetail,ROW_NUMBER() OVER (ORDER BY  Product.[Id]) AS RowNum FROM [ProductManage].[Product].[Product] as Product  inner join [ProductManage].[Product].[DemandSide] as DemanSide  on Product.Id=DemanSide.Id  ) AS T WHERE RowNum > (@pageIndex - 1) * @pageSize AND RowNum <= @pageIndex * @pageSize",
                new { pageIndex, pageSize });

        var enumerable = result.ToList();
        if (enumerable.AsList().Count == 0)
            throw new KeyNotFoundException();

        foreach (var item in enumerable)
        {
            yield return MapClientListDto(result);
        }
    }

    private ClientListDto MapClientListDto(dynamic result)
    {
        var client = new ClientListDto
        {
            Id = result.id,
            ClientType = result.clientType,
            Name = result.name,
            Street = result.street,
            City = result.city,
            Province = result.province,
            ZipCode = result.zipcode,
            ClientAgent = new ClientListDto.ClientListAgentDto(),
            TFN = result.tfn,
            BankTitle = result.bankTitle,
            BillingTelephone = result.billingTelephone,
            ContactNumber = result.contactNumber,
            Email = result.email,
            Fax = result.fax,
        };
        client.ClientAgent.Name = result.clientName;
        client.ClientAgent.PhoneNumber = result.clientPhone;
        return client;
    }
    
}