using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.ChangeAll;

public class ChangeAllTodosStatusCommand
{
    public record ChangeAllTodosQuery(string Name) : IRequest<TodoResponse>;
}