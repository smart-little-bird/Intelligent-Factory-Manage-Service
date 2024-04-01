using Intelligent.Factory.Management.API.Applications.Commands;
using Intelligent.Factory.Management.API.Applications.Queries;
using Intelligent.Factory.Management.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Intelligent.Factory.Management.API.Controllers;

public class EmployeeController : CommonControllerBase
{
    private readonly IMediator _mediator;

    private readonly IEmployeeQueries _employeeQueries;

    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger, IEmployeeQueries employeeQueries)
    {
        _mediator = mediator;
        _logger = logger;
        _employeeQueries = employeeQueries;
    }

    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        var result = await _mediator.Send(createEmployeeCommand);
        _logger.LogInformation($"create the employee succeed: id{result}");
        return Succeed(result, StatusCodes.Status201Created);
    }
    
    [ProducesResponseType(typeof(IEnumerable<EmployeeListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        var result = await _employeeQueries.GetListAsync();
        return Succeed(result, StatusCodes.Status200OK);
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

}