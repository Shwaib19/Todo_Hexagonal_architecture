
using MediatR;

namespace Todo.Application.Todo.Features.Todos.DeleteDone;

public record DeleteTodoDoneQuery() : IRequest<Unit>, IRequest;