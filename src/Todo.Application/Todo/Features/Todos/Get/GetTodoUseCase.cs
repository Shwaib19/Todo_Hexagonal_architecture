using Todo.Application.Contracts;
using Todo.Domain;

namespace Todo.Application.Features.Todo.Get;

public class GetTodoUseCase : IGetTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    
    public  GetTodoUseCase(ITodoRepository todoRepository)
    { _todoRepository = todoRepository; }

    public async Task<IReadOnlyList<TodoResponse>> GetTodos()
    {
        var a = await _todoRepository.GetAll();
       return  a.Select(t => new TodoResponse()
        {
            Id = t.Id,
            Name = t.Name,
            IsDone = t.IsDone
        }).ToList();
        
    }
    
}