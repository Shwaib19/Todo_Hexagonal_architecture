using Todo.Application.Contracts;

namespace Todo.Application.Features.Todo.Create;

public interface ICreateTodoUseCase
{
    public Task<TodoResponse> CreateTodo(string name);
}