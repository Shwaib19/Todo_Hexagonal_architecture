using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.Update;

public interface IUpdateTodoUseCase
{
    public Task<TodoResponse> UpdateTodo(int id, string name, bool isDone);
}