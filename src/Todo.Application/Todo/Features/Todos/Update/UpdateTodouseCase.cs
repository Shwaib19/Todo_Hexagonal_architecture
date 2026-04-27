using Todo.Application.Contracts;
using Todo.Application.RequestObject;
using Todo.Domain;

namespace Todo.Application.Features.Todo.Update;

public class UpdateTodouseCase(ITodoRepository todoRepository) : IUpdateTodoUseCase
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<TodoResponse> UpdateTodo(TodoUpdateRequest todoUpdateRequest)
    {
        var a = await todoRepository.UpdateTodo(todoUpdateRequest.Id, todoUpdateRequest.Name,todoUpdateRequest.IsDone);
        return new TodoResponse()
        {
            Id = a.Id,
            Name = a.Name,
            IsDone = a.IsDone
        };
    }
}