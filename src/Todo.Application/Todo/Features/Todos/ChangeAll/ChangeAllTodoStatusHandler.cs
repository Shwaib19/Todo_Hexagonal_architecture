using MediatR;
using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Application.Todo.Features.Todos.ChangeAll;

public class ChangeAllTodoStatusHandler(IChangeAllTodoStatusUseCase changeAllTodoStatusUseCase)
    : IRequestHandler<ChangeAllTodoStatusHandler>, IRequest
{
    private readonly IChangeAllTodoStatusUseCase _changeAllTodoStatusUseCase = changeAllTodoStatusUseCase;

    public async Task Handle(ChangeAllTodoStatusHandler request, CancellationToken cancellationToken)
    {
        await _changeAllTodoStatusUseCase.ChangeStatus();
    }
}