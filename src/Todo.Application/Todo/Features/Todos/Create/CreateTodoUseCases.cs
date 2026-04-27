using Todo.Application.Contracts;
using Todo.Application.Features.Todo.Create;
using Todo.Domain;

namespace Todo.Application.Features.Todo;

public class CreateTodoUseCases : ICreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    
    public CreateTodoUseCases(ITodoRepository todoRepository)
    { _todoRepository = todoRepository; }
    

    public async Task<TodoResponse> CreateTodo(string name)
    {
        var todo = new TodoItem(name);
        var item = await _todoRepository.AddTodo(todo);
        return  new TodoResponse()
        {
            Id = item.Id,
            Name = item.Name,
            IsDone = item.IsDone
        };
    }
}