

using Todo.Domain;

namespace Todo.Application.Todo.Features.Todos;

public interface ITodoRepository
{
    

    
    public Task<IReadOnlyList<TodoItem>> GetAll();
    public Task<TodoItem> AddTodo(TodoItem todo);
    public Task<TodoItem> UpdateTodo(int id, string? name, bool? isDone);
    public Task ChangeAllStatus();
    public Task DeleteAsync(int id);
    public Task DeleteAllDone();

}

