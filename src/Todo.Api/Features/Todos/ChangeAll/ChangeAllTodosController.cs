using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.ChangeAll;

namespace Todo.Api.Features.Todos.ChangeAll;

public class ChangeAllTodosController (IMediator mediator) : TodoController( mediator)
{
    private readonly IMediator _mediator = mediator;
    
    [HttpPatch("/ToggleAll")]
    public async Task ChangeAllTodo()
    {   
        await _mediator.Send(new ChangeAllTodosQuery());
    }
}