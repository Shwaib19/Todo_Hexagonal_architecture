namespace Todo.Application.Todo.Features.Todos.Delete;

public class DeleteTodoUseCase(ITodoRepository todoRepository) : IDeleteTodoUseCase
{
    public async Task DeleteTodo(int id)
    {
        await todoRepository.DeleteAsync(id);
    }
}