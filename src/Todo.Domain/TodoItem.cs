namespace Todo.Domain;

public class TodoItem
{
    public int Id { get;  set; }
    public string Name { get;  set; }
    public bool IsDone{ get;  set; } = false;

    public TodoItem(string name)
    {
        this.Name = name;
    }
}