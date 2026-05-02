using MediatR;

namespace Todo.Application.Todo.Features.Todos.Get;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IReadOnlyList<TodoResponse>>
{
    private readonly IGetTodoUseCase _getTodoUseCase;
    
    public GetTodosQueryHandler(IGetTodoUseCase getTodoUseCase) =>
    _getTodoUseCase = getTodoUseCase;

    public async Task<IReadOnlyList<TodoResponse>> Handle(GetTodosQuery request,
        CancellationToken cancellationToken)
    {
        return await _getTodoUseCase.GetTodos();
    }
}