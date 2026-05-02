using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.Delete;

namespace Todo.Api.Features.Todos.Delete;

public class DeleteTodoController(IMediator mediator) : TodoController(mediator)
{
    private readonly IMediator _mediator = mediator;
    [HttpDelete("{id}")]
    public async Task DeleteTodoItem(int id)
    {
        await _mediator.Send(new DeleteTodoQuery(id));
    }
}