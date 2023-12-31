using Intelligent.Factory.Management.API.Applications.Commands;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Controllers;

public class ContractController : CommonControllerBase
{
    private readonly IMediator _mediator;

    private readonly IContractQueries _contractQueries;

    private readonly ILogger<ContractController> _logger;

    public ContractController(IMediator mediator, ILogger<ContractController> logger, IContractQueries contractQueries)
    {
        _mediator = mediator;
        _logger = logger;
        _contractQueries = contractQueries;
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

    [ProducesResponseType(typeof(ContractListPageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] Page page)
    {
        var result = await _contractQueries.GetContractListAsync(page.PageIndex, page.PageSize);
        var totalAccount = await _contractQueries.GetAccountAsync();
        var contractListPageDto = new ContractListPageDto
        {
            ContractListDtos = result,
            Page = new PageDto
            {
                PageSize = page.PageSize,
                PageIndex = page.PageIndex,
                Total = totalAccount
            }
        };
        return Succeed(contractListPageDto, StatusCodes.Status200OK);
    }

    [ProducesResponseType(typeof(ContractDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _contractQueries.GetAsync(id);
        return Succeed(result, StatusCodes.Status200OK);
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateContractCommand updateContractCommand)
    {
        var result = await _mediator.Send(updateContractCommand);
        _logger.LogInformation($"update the product succeed: id{result}");
        return Succeed(result, StatusCodes.Status201Created);
    }

    /// <summary>
    /// 完成
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> DownAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new DownContractCommand(id));
        return Succeed(result, StatusCodes.Status201Created);
    }
}
