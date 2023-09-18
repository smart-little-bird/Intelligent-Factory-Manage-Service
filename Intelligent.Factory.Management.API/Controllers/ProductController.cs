using Intelligent.Factory.Management.API.Applications.Commands;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligent.Factory.Management.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class ProductController : CommonControllerBase
{
    private readonly IMediator _mediator;
    
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand createProductCommand)
    {
        var result = await _mediator.Send(createProductCommand);
        _logger.LogInformation($"create the product succeed: id{result}");
        return Succeed(result, StatusCodes.Status201Created);
    }

}