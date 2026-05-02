using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.ChangeAll;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Api.Features.Todos.ChangeAll;

public class ChangeAllTodosController (IMediator mediator) : TodoController( mediator)
{
    private readonly IMediator _mediator = mediator;
    
    [HttpPatch("ToggleAll")]
    public async Task UpdateTodoItem(int id, [FromQuery] TodoUpdateRequest t)
    {   
        t.Id = id ;
        await _mediator.Send(new ChangeAllTodosQuery());
    }
}