using Todo.Application.Todo.Features.Todos.Get;

namespace Todo.Test.Features;

[TestClass]
public sealed  class GetAllTodosEndpointTest
{
    private HttpClient? _client;

    public GetAllTodosEndpointTest(HttpClient? client)
    {
        _client = client;
    }


    public async Task GetAllTodos_ShouldReturnCorrectResult()
    {
        var response = await _client!.GetAsync("/");
        response.EnsureSuccessStatusCode();

    }
    
}