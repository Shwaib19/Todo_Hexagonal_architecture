using Todo.Application.Contracts;
using Todo.Application.RequestObject;

namespace Todo.Application.Features.Todo.Update;

public interface IUpdateTodoUseCase
{
    public Task<TodoResponse> UpdateTodo(TodoUpdateRequest todoUpdateRequest);
}