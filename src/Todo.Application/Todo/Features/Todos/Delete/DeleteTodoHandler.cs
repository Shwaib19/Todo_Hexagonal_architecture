using MediatR;

namespace Todo.Application.Todo.Features.Todos.Delete;

public class DeleteTodoHandler : IRequestHandler<DeleteTodoQuery>
{
    private readonly IDeleteTodoUseCase _deleteTodoUseCase;

    public DeleteTodoHandler(IDeleteTodoUseCase deleteTodoUseCase)
    {
        _deleteTodoUseCase = deleteTodoUseCase;
    }

    public async Task Handle(DeleteTodoQuery request, CancellationToken cancellationToken)
    {
        await _deleteTodoUseCase.DeleteTodo(request.Id);
    }
}