using Todo.Domain;

namespace Todo.Application.Todo.Features.Todos.ChangeAll;

public class ChangeAllTodoStatusUseCase(ITodoRepository todoRepository) : IChangeAllTodoStatusUseCase
{
    public async Task ChangeStatus()
    {
        await todoRepository.ChangeAllStatus();
    }
    
}