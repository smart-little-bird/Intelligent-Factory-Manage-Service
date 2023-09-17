using Intelligent.Factory.Management.API.Applications.Commands;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Intelligent.Factory.Management.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class ClientController : CommonControllerBase
{
    private readonly IMediator _mediator;

    private readonly IClientQueries _clientQueries;

    private readonly ILogger<ClientController> _logger;

    public ClientController(IMediator mediator, IClientQueries clientQueries, ILogger<ClientController> logger)
    {
        _mediator = mediator;
        _clientQueries = clientQueries;
        _logger = logger;
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateClientCommand createClientCommand)
    {
        var result = await _mediator.Send(createClientCommand);
        _logger.LogInformation($"create the client succeed: id{result}");
        return Succeed(result, StatusCodes.Status201Created);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteClientCommand { Id = id });
        return Succeed(StatusCodes.Status200OK);
    }

    [ProducesResponseType(typeof(ClientListPageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("")]
    public async Task<IActionResult> GetListAsync([FromQuery] Page page)
    {
        var result = _clientQueries.GetClientListAsync(page.PageIndex, page.PageSize);
        var totalAccount = await _clientQueries.GetAccountAsync();
        var clientListPageDto = new ClientListPageDto
        {
            ClientListDtos = result,
            Page = new ClientListPageDto.PageDto
            {
                PageSize = page.PageSize,
                PageIndex = page.PageIndex,
                Total = totalAccount
            }
        };
        return Succeed(clientListPageDto, StatusCodes.Status200OK);
    }

    [ProducesResponseType(typeof(IEnumerable<ClientListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("simple")]
    public Task<IActionResult> GetListAsync()
    {
        var result = _clientQueries.GetClientListAsync();
        return Task.FromResult(Succeed(result, StatusCodes.Status200OK));
    }
}