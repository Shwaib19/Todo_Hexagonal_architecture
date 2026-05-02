using MediatR;

namespace Todo.Application.Todo.Features.Todos.Update;

public class UpdateTodoHandler : IRequestHandler<UpdateTodoQuery>
{
    private readonly IUpdateTodoUseCase _updateTodoUseCase;

    public UpdateTodoHandler(IUpdateTodoUseCase updateTodoUseCase)
    {
       _updateTodoUseCase= updateTodoUseCase;
    }

    public async Task Handle(UpdateTodoQuery request, CancellationToken cancellationToken)
    {
        await _updateTodoUseCase.UpdateTodo(request.Id, request.Name, request.IsDone);
    }
}