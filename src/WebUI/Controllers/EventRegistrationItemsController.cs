using EventMX.Application.EventItemsService.Commands;
using EventMX.Application.EventItemsService.Queries;
using EventMX.Registration.Application.EventItems.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EventRegistrationItemsController : ControllerBase
{
    private readonly IMediator _mediator;
    public EventRegistrationItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddEventRegistrationItems([FromBody] CreateEventRegistrationItemsCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetEventRegistrationItems([FromQuery] GetEventRegistrationItemsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetAllEventRegistrationItems()
    {
        return Ok(await _mediator.Send(new GetEventRegistrationItemsListQuery()));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEventRegistrationItems([FromBody] UpdateEventRegistrationItemsCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEventRegistrationItemsAsync([FromQuery] int id)
    {
        return Ok(await _mediator.Send(new DeleteEventRegistrationItemsCommand(id)));
    }
}
