
using MediatR;

namespace Todo.Application.Todo.Features.Todos.DeleteDone;

public record DeleteTodosDoneQuery : IRequest<Unit>,IRequest 
{
    
}