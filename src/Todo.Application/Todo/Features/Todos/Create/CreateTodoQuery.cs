using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.Create;


    public record CreateTodoQuery(string Name) : IRequest<TodoResponse>, IRequest;