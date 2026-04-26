using Microsoft.EntityFrameworkCore;
using Todo.Application.Contracts;
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
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<IReadOnlyList<TodoItem>> GetAll()
    {
       return await _context.TodoItems.ToListAsync();
    }
    
    public async Task<TodoItem> UpdateTodo(int id, string? name, bool? isDone)
    {
        TodoItem? a = await _context.TodoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (a != null)
        {
            var result =a.Update(name, isDone);

            await _context.SaveChangesAsync();
            return result;
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
                todo.MarkDone();
            }
        }
        else
        {
            foreach (TodoItem todo in todos)
            {
                todo.ChangeStatus();
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
            if (item.Status())
            {
                _context.TodoItems.Remove(item); 
            }
        }
        await _context.SaveChangesAsync();
    }
    

}