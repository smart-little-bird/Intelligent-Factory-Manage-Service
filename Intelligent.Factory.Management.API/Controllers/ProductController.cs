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

    private readonly IProductQueries _productQueries;

    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger, IProductQueries productQueries)
    {
        _mediator = mediator;
        _logger = logger;
        _productQueries = productQueries;
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
    
    [ProducesResponseType(typeof(ProductPageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] Page page)
    {
        var result = await _productQueries.GetProductListAsync(page.PageIndex, page.PageSize);
        return Succeed(result, StatusCodes.Status201Created);
    }
}