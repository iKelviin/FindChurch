using FindChurch.Application.Commands.MinistryCommands.CreateMinistry;
using FindChurch.Application.Commands.MinistryCommands.DeleteMinistry;
using FindChurch.Application.Commands.MinistryCommands.UpdateMinistry;
using FindChurch.Application.Queries.MinistryQueries.GetAllMinistries;
using FindChurch.Application.Queries.MinistryQueries.GetAllMinistriesByIdChurch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindChurch.API.Controllers;

[ApiController]
[Route("api/ministries")]
public class MinistriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MinistriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllMinistriesQuery());
        if(!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }
    
    [HttpGet("by-church/{id:guid}")]
    public async Task<IActionResult> GetByChurch(Guid id)
    {
        var result = await _mediator.Send(new GetAllMinistriesByIdChurchQuery(id));
        if(!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateMinistryCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateMinistryCommand command)
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