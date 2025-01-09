using FindChurch.Application.Commands.MinistryCommands.DeleteMinistry;
using FindChurch.Application.Commands.WorshipServiceCommands.CreateWorshipService;
using FindChurch.Application.Commands.WorshipServiceCommands.UpdateWorshipService;
using FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServices;
using FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServicesByIdChurch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindChurch.API.Controllers;

[ApiController]
[Route("api/worship-services")]
public class WorshipServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorshipServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllWorshipServicesQuery());
        if(!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }
    
    [HttpGet("by-church/{id:guid}")]
    public async Task<IActionResult> GetByChurch(Guid id)
    {
        var result = await _mediator.Send(new GetAllWorshipServicesByIdChurchQuery(id));
        if(!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateWorshipServiceCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateWorshipServiceCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteMinistryCommand());
        if (!result.IsSuccess) return BadRequest(result.Message);
        return NoContent();
    }
}