namespace Todo.Application.Todo.Features.Todos.Get;

public interface IGetTodoUseCase
{
    public Task<IReadOnlyList<TodoResponse>> GetTodos();
}