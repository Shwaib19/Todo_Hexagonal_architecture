namespace Todo.Application.Todo.Features.Todos.Delete;

public interface IDeleteTodoUseCase
{
    public Task DeleteTodo(int id);
}