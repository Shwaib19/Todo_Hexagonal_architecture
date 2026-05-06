using Todo.Application.Todo.Features.Todos.Get;
using Todo.Domain;

namespace Todo.Application.Todo.Features.Todos.Create;

public class CreateTodoUseCases(ITodoRepository todoRepository) : ICreateTodoUseCase
{
    public async Task<TodoResponse> CreateTodo(string name)
    {
        var todo = TodoItem.Create(name);
        var item = await todoRepository.AddTodo(todo);
        return  new TodoResponse()
        {
            Id = item.Id,
            Name = item.Name,
            IsDone = item.IsDone
        };
    }
}