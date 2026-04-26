using Todo.Domain;

namespace Todo.Application.Features.Todo.DeleteDone;

public class DeleteTodosDoneUseCase: IDeleteTodosDoneUseCase
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodosDoneUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    public async Task DeleteTodoDone()
    {
       await _todoRepository.DeleteAllDone();
    }
}