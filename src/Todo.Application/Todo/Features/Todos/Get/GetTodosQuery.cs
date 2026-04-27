using MediatR;
using Todo.Application.Contracts;

namespace Todo.Application.Features.Todo.Get;

public class GetTodosQuery:  IRequest<IReadOnlyList<TodoResponse>>
{
    
}