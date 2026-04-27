using MediatR;

namespace Todo.Application.Todo.Features.Todos.Delete;

public record DeleteCommand(int Id):  IRequest<Unit>;