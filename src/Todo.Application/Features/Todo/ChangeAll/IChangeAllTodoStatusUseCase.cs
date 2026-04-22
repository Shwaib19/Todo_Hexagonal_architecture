using Todo.Domain;

namespace Todo.Application.Features.Todo.ChangeAll;

public interface IChangeAllTodoStatusUseCase
{
    public Task<IEnumerable<TodoItem>> ChangeStatus();
}