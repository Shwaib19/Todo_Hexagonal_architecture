namespace Todo.Application.Todo.Features.Todos.Get;

public class GetTodoUseCase(ITodoRepository todoRepository) : IGetTodoUseCase
{
    public async Task<IReadOnlyList<TodoResponse>> GetTodos()
    {
        var a = await todoRepository.GetAll();
       return  a.Select(t => new TodoResponse()
        {
            Id = t.Id,
            Name = t.Name,
            IsDone = t.IsDone
        }).ToList();
        
    }
    
}