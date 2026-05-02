using MediatR;

namespace Todo.Application.Todo.Features.Todos.Get;

public class GetTodosQuery:  IRequest<IReadOnlyList<TodoResponse>>
{
    
}