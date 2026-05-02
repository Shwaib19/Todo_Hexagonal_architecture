using MediatR;

namespace Todo.Application.Todo.Features.Todos.Delete;

public record DeleteTodoQuery(int Id):  IRequest<Unit>, IRequest;