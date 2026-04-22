using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace Todo.Infrastructure;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;
    
    public TodoRepository(AppDbContext db)
    {
        _context = db;
        
    }
    
    public async Task<TodoItem> AddTodo(TodoItem todo)
    {
        _context.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<IEnumerable<TodoItem>> GetAll()
    {
        await _context.TodoItems.ToListAsync();
        return await Task.FromResult<IEnumerable<TodoItem>>(_context.TodoItems);
    }
    
    public async Task UpdateTodo(int id, string? name, bool? isDone)
    {
        TodoItem? a = await _context.TodoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (a != null)
        {
            if (name !=null && a.Name != name )
            {
                a.Name = name;
            }

            else if (isDone != null && a.IsDone != isDone)
            {
                a.IsDone = !a.IsDone;
            }
            else
            {
                throw new KeyNotFoundException(); 
            }
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    public async Task ChangeAllStatus()
    {
        var todos = await _context.TodoItems.ToListAsync();
        var unfinishedTodos = todos.Any(t => t.IsDone == false);
        if (unfinishedTodos)
        {
            foreach (TodoItem todo in todos)
            {
                todo.IsDone = true;
            }
        }
        else
        {
            foreach (TodoItem todo in todos)
            {
                todo.IsDone = false;
            }
        }
        await _context.SaveChangesAsync();
    }
    

    public async Task DeleteAsync(int id)
    {
        TodoItem? a = await _context.TodoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (a != null)
        {
            _context.TodoItems.Remove(a);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }
    
    public async  Task DeleteAllDone()
    {
        var todos = await _context.TodoItems.ToListAsync();
        foreach (var item in todos)
        {
            if (item.IsDone == true)
            {
                _context.TodoItems.Remove(item); 
            }
        }
        await _context.SaveChangesAsync();
    }
    

}