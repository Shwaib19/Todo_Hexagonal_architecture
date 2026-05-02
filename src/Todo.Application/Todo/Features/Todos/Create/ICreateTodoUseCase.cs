using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.Create;

public interface ICreateTodoUseCase
{
    public Task<TodoResponse> CreateTodo(string name);
}