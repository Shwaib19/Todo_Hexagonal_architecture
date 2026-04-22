using Todo.Application.Contracts;
using Todo.Domain;

namespace Todo.Application.Features.Todo.Get;

public class GetTodoUseCase : IGetTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    
    public  GetTodoUseCase(ITodoRepository todoRepository)
    { _todoRepository = todoRepository; }

    public async Task<IEnumerable<TodoItem>> GetTodos()
    {
        return await _todoRepository.GetAll();
    }
    
}