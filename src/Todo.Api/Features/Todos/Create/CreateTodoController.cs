using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.Create;

namespace Todo.Api.Features.Todos.Create;

public class CreateTodoController(IMediator mediator) : TodoController(mediator)
{
    private readonly IMediator _mediator = mediator;
    [HttpPost]
    public async Task CreateTodo(string name)
    {
        await _mediator.Send(new CreateTodoQuery(name));
    }
}