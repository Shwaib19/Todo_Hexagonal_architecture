

namespace Todo.Domain;

public interface ITodoRepository
{
    

    
    public Task<IEnumerable<TodoItem>> GetAll();
    public Task<TodoItem> AddTodo(TodoItem todo);
    public Task UpdateTodo(int id, string? name, bool? isDone);
    public Task ChangeAllStatus();
    public Task DeleteAsync(int id);
    public Task DeleteAllDone();

}

