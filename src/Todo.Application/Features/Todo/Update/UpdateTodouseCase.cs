using Todo.Application.RequestObject;
using Todo.Domain;

namespace Todo.Application.Features.Todo.Update;

public class UpdateTodouseCase(ITodoRepository todoRepository) : IUpdateTodoUseCase
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task UpdateTodo(TodoUpdateRequest todoUpdateRequest)
    {
        await todoRepository.UpdateTodo(todoUpdateRequest.Id, todoUpdateRequest.Name,todoUpdateRequest.IsDone);
    }
}