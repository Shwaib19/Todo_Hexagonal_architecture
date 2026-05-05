using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace Todo.TestXunit;

public class GetTodoTest : IClassFixture<WebApplicationFactory<Program>>
{
    
    private readonly WebApplicationFactory<Program> _factory;

    public GetTodoTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetTodo_Should_Return_TodoItem()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Todos");
        response.EnsureSuccessStatusCode();
        Assert.NotNull(response);
    }
    
}