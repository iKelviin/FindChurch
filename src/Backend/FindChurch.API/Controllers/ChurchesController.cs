using FindChurch.Application.Commands.ChurchCommands.CreateChurch;
using FindChurch.Application.Commands.ChurchCommands.DeleteChurch;
using FindChurch.Application.Commands.ChurchCommands.UpdateChurch;
using FindChurch.Application.Queries.ChurchQueries.GetAllChurches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindChurch.API.Controllers;

[ApiController]
[Route("api/churches")]
public class ChurchesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChurchesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllChurchesQuery());
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateChurchCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateChurchCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteChurchCommand(id));
        if (!result.IsSuccess) return BadRequest(result.Message);
        return NoContent();
    }
}