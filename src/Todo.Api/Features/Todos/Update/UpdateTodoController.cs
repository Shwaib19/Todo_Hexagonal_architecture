using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.Get;
using Todo.Application.Todo.Features.Todos.Update;

namespace Todo.Api.Features.Todos.Update;

public class UpdateTodoController (IMediator mediator) : TodoController(mediator)
{
    private readonly IMediator _mediator = mediator;
    
    
    [HttpPatch]
    public async Task UpdateTodoItem(int id, string name, bool isDone)
    {  
        await _mediator.Send(new UpdateTodoQuery(id,  name, isDone ));
    }
}