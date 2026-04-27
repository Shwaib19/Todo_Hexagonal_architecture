namespace Todo.Api.Features.Todos;

public class TodoUpdateRequest
{
    public int Id { get;  set; }
    public string? Name { get;  set; }
    public bool? IsDone{ get;  set; }
}