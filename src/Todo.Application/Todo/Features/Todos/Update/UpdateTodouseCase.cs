using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.Update;

public class UpdateTodouseCase(ITodoRepository todoRepository) : IUpdateTodoUseCase
{
    public async Task<TodoResponse> UpdateTodo(int id, string name, bool isDone)
    {
        var a = await todoRepository.UpdateTodo(id, name, isDone);
        return new TodoResponse()
        {
            Id = a.Id,
            Name = a.Name,
            IsDone = a.IsDone
        };
    }
}