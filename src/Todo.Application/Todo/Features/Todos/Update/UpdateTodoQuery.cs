using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.Update;

public record UpdateTodoQuery(int Id, string Name, bool IsDone ) : IRequest<TodoResponse>, IRequest;