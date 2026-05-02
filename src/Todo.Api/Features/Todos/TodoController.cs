using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Features.Todos;

[ApiController]
[Route("api/Todos")]
public class TodoController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
}