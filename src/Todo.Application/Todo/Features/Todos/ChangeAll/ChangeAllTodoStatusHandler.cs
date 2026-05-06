using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.ChangeAll;

public class ChangeAllTodoStatusHandler : IRequestHandler<ChangeAllTodosQuery>, IRequest
{
    private readonly IChangeAllTodoStatusUseCase _changeAllTodoStatusUseCase;

    public ChangeAllTodoStatusHandler( IChangeAllTodoStatusUseCase changeAllTodoStatusUseCase)
    {
        _changeAllTodoStatusUseCase = changeAllTodoStatusUseCase;
    }
    

    public async Task Handle(ChangeAllTodosQuery request, CancellationToken cancellationToken)
    {
        await _changeAllTodoStatusUseCase.ChangeStatus();
    }
}