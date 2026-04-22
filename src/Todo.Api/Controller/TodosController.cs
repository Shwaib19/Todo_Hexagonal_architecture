using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using Todo.Application.Features.Todo.ChangeAll;
using Todo.Application.Features.Todo.Create;
using Todo.Application.Features.Todo.Delete;
using Todo.Application.Features.Todo.DeleteDone;
using Todo.Application.Features.Todo.Get;
using Todo.Application.Features.Todo.Update;
using Todo.Application.RequestObject;
using Todo.Domain;


namespace todo.Api.Controller;

[ApiController]
[Route("Api/Todos")]
public class TodosController : ControllerBase
{
    private readonly IGetTodoUseCase _IGetTodoUseCase;
    private readonly ICreateTodoUseCase _ICreateTodoUseCase;
    private readonly IUpdateTodoUseCase _IUpdateTodoUseCase;
    private readonly IDeleteTodoUseCase _IDeleteTodoUseCase;
    private readonly IDeleteTodosDoneUseCase _iDeleteTodosDoneUseCase;
    private readonly IChangeAllTodoStatusUseCase _iChangeAllTodoStatusUseCase;
    

    public TodosController(
        IGetTodoUseCase IGetTodoUseCase,
        ICreateTodoUseCase iCreateTodoUseCase,
        IUpdateTodoUseCase IUpdateTodoUseCase,
        IDeleteTodoUseCase IDeleteTodoUseCase,
        IDeleteTodosDoneUseCase deleteTodosDoneUseCase,
        IChangeAllTodoStatusUseCase changeAllTodoStatusUseCase)
    {
        _IGetTodoUseCase = IGetTodoUseCase;
        _ICreateTodoUseCase = iCreateTodoUseCase;
        _IUpdateTodoUseCase = IUpdateTodoUseCase;
        _IDeleteTodoUseCase = IDeleteTodoUseCase;
        _iDeleteTodosDoneUseCase = deleteTodosDoneUseCase;
        _iChangeAllTodoStatusUseCase = changeAllTodoStatusUseCase;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        return await _IGetTodoUseCase.GetTodos() ;
    }

    [HttpPost]
    public async Task<IEnumerable<TodoItem>> AddTodoItem( [FromQuery] TodoCreateRequest todoItem)
    {
    await _ICreateTodoUseCase.CreateTodo(todoItem.Name);
     return await _IGetTodoUseCase.GetTodos();   
    }

    [HttpPatch]
    public async Task<IEnumerable<TodoItem>> UpdateTodoItem(int id, [FromQuery] TodoUpdateRequest t)
    {   
        t.Id = id ;
        await _IUpdateTodoUseCase.UpdateTodo(t);
        return await _IGetTodoUseCase.GetTodos();
    }

    [HttpDelete("{id}")]
    public async Task<IEnumerable<TodoItem>> DeleteTodoItem(int id)
    {
        await _IDeleteTodoUseCase.DeleteTodo(id);
        return await _IGetTodoUseCase.GetTodos();
    }

    [HttpDelete("/status")]
    public async Task<IEnumerable<TodoItem>> DeleteTodoStatus()
    {
        await _iDeleteTodosDoneUseCase.DeleteTodoDone();
        return await _IGetTodoUseCase.GetTodos();
    }
}