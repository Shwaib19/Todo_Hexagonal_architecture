using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Api.Features.Todos;

[ApiController]
[Route("api/Todos")]
public class GetAllTodosController: ControllerBase

{
    private readonly IMediator _mediator;

    public GetAllTodosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<TodoResponse>> GetTodoItems()
    {
        return await _mediator.Send(new GetTodosQuery()) ;
    }
}