using Dapper;
using Intelligent.Factory.Management.API.DTOs;
using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Microsoft.Data.SqlClient;

namespace Intelligent.Factory.Management.API.Applications.Queries;

public class ClientQueries : IClientQueries
{
    private readonly string _connectionString;

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
            "SELECT * FROM (SELECT Client.Id as ID, CLIENTTYPE, Client.Name as NAME, STREET, CITY,PROVINCE,ZIPCODE,TFN, BANKTITLE, BANKACCOUNT,BILLINGTELEPHONE, CONTACTNUMBER, EMAIL, FAX,ROW_NUMBER() OVER (ORDER BY  Client.Id) AS RowNum,cA.Name as CLIENTNAME,cA.PhoneNumber as CLIENTPHONE FROM  IntelligentFactoryManagement.client AS Client inner join IntelligentFactoryManagement.clientAgent cA on cA.Id = Client.ClientAgentId) AS T WHERE RowNum > (@pageIndex - 1) * @pageSize AND RowNum <= @pageIndex * @pageSize",
            new { pageIndex, pageSize });
        var enumerable = result.ToList();
        if (enumerable.AsList().Count == 0)
            throw new KeyNotFoundException();

        foreach (var item in enumerable)
        {
            yield return MapClientListDto(item);
        }
    }

    public async Task<int> GetAccountAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var result =
            await connection.QueryAsync<int>(sql: $"SELECT COUNT(1) FROM IntelligentFactoryManagement.client");
        return result.First();
    }

    public async IAsyncEnumerable<ClientListDto> GetClientListAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var result = await connection.QueryAsync<dynamic>(
            sql:
            "  SELECT Client.Id as ID,CLIENTTYPE, Client.Name as NAME,STREET, CITY,PROVINCE,ZIPCODE,TFN,BANKTITLE, BANKACCOUNT,BILLINGTELEPHONE, CONTACTNUMBER, EMAIL, FAX,cA.Name as CLIENTNAME,cA.PhoneNumber as CLIENTPHONE FROM  IntelligentFactoryManagement.client AS Client inner join IntelligentFactoryManagement.clientAgent cA on cA.Id = Client.ClientAgentId");
        var enumerable = result.ToList();
        if (enumerable.AsList().Count == 0)
            throw new KeyNotFoundException();
        foreach (var item in enumerable)
        {
            yield return MapClientListDto(item);
        }
    }

    private static ClientListDto MapClientListDto(dynamic result)
    {
        var client = new ClientListDto
        {
            Id = result.ID,
            ClientType = (ClientType)result.CLIENTTYPE,
            Name = result.NAME,
            Street = result.STREET,
            City = result.CITY,
            Province = result.PROVINCE,
            ZipCode = result.ZIPCODE,
            ClientAgent = new ClientListDto.ClientListAgentDto(),
            TFN = result.TFN,
            BankTitle = result.BANKTITLE,
            BankAccount = result.BANKACCOUNT,
            BillingTelephone = result.BILLINGTELEPHONE,
            ContactNumber = result.CONTACTNUMBER,
            Email = result.EMAIL,
            Fax = result.FAX,
        };
        client.ClientAgent.Name = result.CLIENTNAME;
        client.ClientAgent.PhoneNumber = result.CLIENTPHONE;
        return client;
    }
}