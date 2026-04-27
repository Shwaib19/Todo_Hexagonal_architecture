using Todo.Application.Contracts;
using Todo.Domain;

namespace Todo.Application.Features.Todo.Get;

public interface IGetTodoUseCase
{
    public Task<IReadOnlyList<TodoResponse>> GetTodos();
}