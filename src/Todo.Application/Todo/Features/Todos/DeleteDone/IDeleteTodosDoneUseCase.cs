using Todo.Domain;

namespace Todo.Application.Features.Todo.DeleteDone;

public interface IDeleteTodosDoneUseCase
{
    public Task DeleteTodoDone();
}