using Intelligent.Factory.Management.API.Applications.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class ContractController : CommonControllerBase
{
    private readonly IMediator _mediator;

    private readonly ILogger<ContractController> _logger;

    public ContractController(IMediator mediator, ILogger<ContractController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateContractCommand createContractCommand)
    {
        var result = await _mediator.Send(createContractCommand);
        _logger.LogInformation($"create the product succeed: id{result}");
        return Succeed(result, StatusCodes.Status201Created);
    }

}
