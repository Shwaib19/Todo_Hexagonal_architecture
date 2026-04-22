using Todo.Application.Contracts;

namespace Todo.Application.Features.Todo.Delete;

public interface IDeleteTodoUseCase
{
    public Task DeleteTodo(int id);
}