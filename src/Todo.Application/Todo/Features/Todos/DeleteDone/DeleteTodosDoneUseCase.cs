namespace Todo.Application.Todo.Features.Todos.DeleteDone;

public class DeleteTodosDoneUseCase(ITodoRepository todoRepository) : IDeleteTodosDoneUseCase
{
    public async Task DeleteTodoDone()
    {
       await todoRepository.DeleteAllDone();
    }
}