namespace Todo.Test.Features;
[TestClass]
public sealed class CreateTodoEndpointTest
{
    private HttpClient? _client;

    public CreateTodoEndpointTest(HttpClient? client)
    {
        _client = client;
    }

    public async Task CreateTodo()
    {
        var response = await _client!.PostAsync("/", new StringContent("test0"));
    }
}