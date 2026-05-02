using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Api.Features.Todos.Get;


public class GetAllTodosController(IMediator mediator) : TodoController(mediator)

{
    private readonly IMediator _mediator = mediator;
    

    [HttpGet]
    public async Task<IReadOnlyList<TodoResponse>> GetTodoItems()
    {
        return await _mediator.Send(new GetTodosQuery()) ;
    }
}