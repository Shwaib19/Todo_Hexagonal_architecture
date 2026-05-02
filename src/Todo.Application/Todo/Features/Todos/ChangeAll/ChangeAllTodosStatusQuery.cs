using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.ChangeAll;


    public record ChangeAllTodosQuery() : IRequest<Unit>;
