using MediatR;

namespace Todo.Application.Todo.Features.Todos.Create;

public class CreateTodoHandler : IRequestHandler<CreateTodoQuery>
{
    private readonly ICreateTodoUseCase _createTodoUseCase;

    public CreateTodoHandler(ICreateTodoUseCase createTodoUseCase)
    {
        _createTodoUseCase = createTodoUseCase;
    }

    public async Task Handle(CreateTodoQuery request, CancellationToken cancellationToken)
    {
        await _createTodoUseCase.CreateTodo(request.Name);
    }
}