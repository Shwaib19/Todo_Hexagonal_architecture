namespace Todo.Application.Contracts;

public class TodoResponse
{
    public int Id { get;  set; }
    public string Name { get;  set; }
    public bool IsDone{ get;  set; }
}