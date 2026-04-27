namespace Todo.Application.Features.Todo.ChangeAll;

public class ChangeAllTodoStatusHandler
{
        private readonly IChangeAllTodoStatusUseCase _iChangeAllTodoStatusUseCase;
        
        public ChangeAllTodoStatusHandler(IChangeAllTodoStatusUseCase iChangeAllTodoStatusUseCase) =>
        _iChangeAllTodoStatusUseCase = iChangeAllTodoStatusUseCase;

        public async Task HandleAsync()
        {
                _iChangeAllTodoStatusUseCase.ChangeStatus();
        }

}