using Todo.Application.RequestObject;

namespace Todo.Application.Features.Todo.Update;

public interface IUpdateTodoUseCase
{
    public Task UpdateTodo(TodoUpdateRequest todoUpdateRequest);
}