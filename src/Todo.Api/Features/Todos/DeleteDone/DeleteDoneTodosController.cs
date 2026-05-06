using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.DeleteDone;

namespace Todo.Api.Features.Todos.DeleteDone;

public class DeleteDoneTodosController(IMediator mediator) : TodoController(mediator)

{
    private readonly IMediator _mediator = mediator;
    
    [HttpDelete("/status")]
    public async Task DeleteTodoStatus()
    {
        await _mediator.Send(new DeleteTodosDoneQuery());

    }
}