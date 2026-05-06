using MediatR;
using Todo.Application.Todo.Features.Todos.Delete;

namespace Todo.Application.Todo.Features.Todos.DeleteDone;

public class DeleteTodosDoneHandler : IRequestHandler<DeleteTodosDoneQuery>, IRequest
{
    private readonly IDeleteTodosDoneUseCase _deleteTodosDoneUseCase;

    public DeleteTodosDoneHandler(IDeleteTodosDoneUseCase deleteTodosDoneUseCase)
    {
        _deleteTodosDoneUseCase =deleteTodosDoneUseCase;
    }

    public async Task Handle(DeleteTodosDoneQuery request, CancellationToken cancellationToken)
    {
        await _deleteTodosDoneUseCase.DeleteTodoDone();
    }
}