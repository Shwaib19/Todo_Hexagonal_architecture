using Todo.Domain;

namespace Todo.Application.Features.Todo.ChangeAll;

public class ChangeAllTodoStatusUseCase : IChangeAllTodoStatusUseCase
{
    private readonly ITodoRepository _todoRepository;

    public ChangeAllTodoStatusUseCase(ITodoRepository todoRepository)
    { _todoRepository = todoRepository; }

    public async Task ChangeStatus()
    {
        await _todoRepository.ChangeAllStatus();
        await _todoRepository.GetAll();
    }

    public Task<IEnumerable<TodoItem>> GetTodos()
    {
        throw new NotImplementedException();
    }
}