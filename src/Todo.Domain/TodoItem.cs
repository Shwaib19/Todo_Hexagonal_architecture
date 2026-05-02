namespace Todo.Domain;

public class TodoItem(string name)
{
    public int Id { get; private  set; }
    public string Name { get;private  set; } = name;
    public bool IsDone{ get; private set; } = false;

    public TodoItem Update(string? name, bool? isDone)
    {
        if (name !=null && this.Name != name )
        {
            this.Name = name;
        }
        if (isDone != null && this.IsDone != isDone)
        {
            this.IsDone = !this.IsDone;
        }
        return this;
    }

    public bool Status()
    {
        return this.IsDone;
    }

    public void ChangeStatus()
    {
        IsDone = !IsDone;
    }
    
    public void MarkDone()
    {
        if (!IsDone)
        {
            IsDone = true;
        }
    }

    public static TodoItem Create(string name)
    {
        if (name.Length == 0)
        {
            throw new ArgumentException("Le nom ne doit pas etre vide");
        }
        else if (name.Length < 3)
        {
            throw new ArgumentException("Le nom doit contenir au moins 3 caracteres");
        }
        else if (name.Length > 100)
        {
            throw new ArgumentException("Le nom ne doit pas contenir plus de 100 caracteres");
        }
        else
        {
            return new TodoItem(name);
        }
        
    }
}