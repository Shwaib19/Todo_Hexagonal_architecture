using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Todo.Application.Features.Todo;
using Todo.Application.Features.Todo.ChangeAll;
using Todo.Application.Features.Todo.Create;
using Todo.Application.Features.Todo.Delete;
using Todo.Application.Features.Todo.DeleteDone;
using Todo.Application.Features.Todo.Get;
using Todo.Application.Features.Todo.Update;
using Todo.Domain;
using Todo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=../Todo.Infrastructure/app.db"));

builder.Services.AddControllers();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ICreateTodoUseCase, CreateTodoUseCases>();
builder.Services.AddScoped<IGetTodoUseCase, GetTodoUseCase>();
builder.Services.AddScoped<IUpdateTodoUseCase, UpdateTodouseCase>();
builder.Services.AddScoped<IDeleteTodoUseCase, DeleteTodoUseCase>();
builder.Services.AddScoped<IChangeAllTodoStatusUseCase, ChangeAllTodoStatusUseCase>();
builder.Services.AddScoped<IDeleteTodosDoneUseCase, DeleteTodosDoneUseCase>();

builder.Services.AddScoped<TodoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapControllers();

app.UseHttpsRedirection();

app.Run();