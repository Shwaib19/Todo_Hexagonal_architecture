using Todo.Domain;

namespace Todo.Application.Features.Todo.Delete;

public class DeleteTodoUseCase: IDeleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    
    public DeleteTodoUseCase(ITodoRepository todoRepository)
    { _todoRepository = todoRepository; }

    public async Task DeleteTodo(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }
}