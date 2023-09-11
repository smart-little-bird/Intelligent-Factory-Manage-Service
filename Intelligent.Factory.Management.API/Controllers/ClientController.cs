using Intelligent.Factory.Management.API.Applications.Commands;
using Intelligent.Factory.Management.API.Applications.Queries;
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
        return Succeed<int>(result, StatusCodes.Status201Created);
    }
    
    // [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // [HttpPut]
    // public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand updateProductCommand)
    // {
    //     var result = await _mediator.Send(updateProductCommand);
    //     _logger.LogInformation($"update the product succeed: id{result}");
    //     return Succeed(result, StatusCodes.Status200OK);
    // }
    //
    // [ProducesResponseType(typeof(ProductPageListDto), StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // [HttpGet("")]
    // public async Task<IActionResult> GetListAsync([FromQuery] Page page)
    // {
    //     var result = await _productQueries.GetList(page.PageIndex,page.PageSize);
    //     return Succeed(result, StatusCodes.Status200OK);
    // }
    //
    // [ProducesResponseType(typeof(ProductDetailDto), StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // [HttpGet("{id:int}")]
    // public async Task<IActionResult> GetAsync([FromRoute] int id)
    // {
    //     var result = await _mediator.Send(new QueryProductDetailCommand(id));
    //     return Succeed(result, StatusCodes.Status200OK);
    // }

}