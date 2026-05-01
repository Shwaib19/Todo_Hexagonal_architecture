using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Test.Features;

[TestClass]
public sealed  class GetAllTodosControllerTest
{
    private HttpClient? _client;

    public GetAllTodosControllerTest(HttpClient? client)
    {
        _client = client;
    }

    [TestMethod]
    public async Task GetAllTodos_ShouldReturnCorrectResult()
    {
        var response = await _client!.GetAsync("/");
        response.EnsureSuccessStatusCode();

    }
    
}