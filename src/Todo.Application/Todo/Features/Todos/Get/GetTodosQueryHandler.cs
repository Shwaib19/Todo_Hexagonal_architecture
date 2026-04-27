using MediatR;
using Todo.Application.Contracts;
using Todo.Domain.Commands;

namespace Todo.Application.Features.Todo.Get;

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