using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Todo.Domain;
using Todo.Infrastructure;
using Xunit.Abstractions;


namespace Todo.TestXunit;

public class TodoContollersTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    
    private readonly CustomWebApplicationFactory<Program> _factory;

    public TodoContollersTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetTodo_Should_Return_TodoItem()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.TodoItems.Add(new TodoItem  (" test"));
            await db.SaveChangesAsync();
        }
        
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/Todos");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        var todos = await response.Content.ReadFromJsonAsync<IEnumerable<TodoItem>>();
        Assert.NotNull(todos);
    }

    [Fact]
    public async Task CreateTodo_should_Return_OK()
    {
        var client = _factory.CreateClient();
        var response = await client.PostAsync("/api/Todos?name=test0",null);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
        
    [Fact]
    public async Task DeleteTodo_Should_Return_OK()
    {
        int todoId;
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var todo = new TodoItem("test0");
            db.TodoItems.Add(todo);
            await db.SaveChangesAsync();
            todoId = todo.Id;
        }
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync($"/api/Todos/{todoId}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateTodo_Should_Return_OK()
    {
        int todoId;
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var todo = new TodoItem("test0");
            db.TodoItems.Add(todo);
            await db.SaveChangesAsync();
            todoId = todo.Id;
        }
        string name = "test1";
        bool isdone = true;
        var client = _factory.CreateClient();
        var response = await client.PatchAsync($"/api/Todos?id={todoId}&name=test1&isDone=true", null);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task DeleteDoneTodo_Should_Return_OK()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var todo = new TodoItem("test0");
            todo.MarkDone();
            db.TodoItems.Add(todo);
            var todo1 = new TodoItem("test1");
            db.TodoItems.Add(todo1);
            await db.SaveChangesAsync();

        }
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync("/status");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
    }

    [Fact]
    public async Task ChangeAllTodoStatus_Should_Return_OK()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var todo = new TodoItem("test0");
            todo.MarkDone();
            db.TodoItems.Add(todo);
            var todo1 = new TodoItem("test1");
            db.TodoItems.Add(todo1);
            await db.SaveChangesAsync();

        }
        var client = _factory.CreateClient();
        var response = await client.PatchAsync("/ToggleAll", null);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
}