using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Todo.Features.Todos.ChangeAll;
using Todo.Application.Todo.Features.Todos.Create;
using Todo.Application.Todo.Features.Todos.Delete;
using Todo.Application.Todo.Features.Todos.DeleteDone;
using Todo.Application.Todo.Features.Todos.Get;
using Todo.Application.Todo.Features.Todos.Update;

namespace Todo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       services.AddScoped<ICreateTodoUseCase, CreateTodoUseCases>();
       services.AddScoped<IGetTodoUseCase, GetTodoUseCase>();
       services.AddScoped<IUpdateTodoUseCase, UpdateTodouseCase>();
       services.AddScoped<IDeleteTodoUseCase, DeleteTodoUseCase>();
       services.AddScoped<IChangeAllTodoStatusUseCase, ChangeAllTodoStatusUseCase>();
       services.AddScoped<IDeleteTodosDoneUseCase, DeleteTodosDoneUseCase>();
       services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
       return services;
    }
}