using Todo.Domain;

namespace Todo.TestXunit;

public class TodoItemTest
{
    [Fact]
    public void Create_Todo_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.NotNull(todoItem); 
        Assert.Equal("test0", todoItem.Name);
        Assert.False(todoItem.IsDone);
    }

    [Fact]
    public void Update_Todo_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update("test1", true);
        Assert.True(todoItem.IsDone);
        Assert.Equal("test1", todoItem.Name);
    }

    [Fact]
    public void Update_Todo_WithOnlyName_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update("test1",null);
        Assert.False(todoItem.IsDone);
        Assert.Equal("test1", todoItem.Name);
    }

    [Fact]
    public void Update_Todo_WithOnlyIsDone_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update(null,true);
        Assert.Equal("test0", todoItem.Name);
        Assert.True(todoItem.IsDone);
    }

    [Fact]
    public void Status_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.Equal(todoItem.IsDone,todoItem.Status());
    }

    [Fact]
    public void Status_ShouldChangeIsDoneValue()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.False(todoItem.IsDone);
        todoItem.ChangeStatus();
        Assert.True(todoItem.IsDone);
        todoItem.ChangeStatus();
        Assert.False(todoItem.IsDone);
    }
    
    [Fact]
    public void Markdone_ShouldSetIsDoneToTrue()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.False(todoItem.IsDone);
        todoItem.MarkDone();
        Assert.True(todoItem.IsDone);
        todoItem.MarkDone();
        Assert.True(todoItem.IsDone);
    }
    
    [Fact]
    public void Create_Should_ThrowException_When_NameLenghtLessThan3()
    {
        Assert.Throws<ArgumentException>(() => TodoItem.Create("t"));

    }
    [Fact]
    public void Create_Should_ThrowException_When_NameIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => TodoItem.Create(""));
    }
    [Fact]
    public void Create_Should_ThrowException_When_NameIsMoreThan100Characters()
    {
        string name = new string('a', 101);
        Assert.Throws<ArgumentException>(() => TodoItem.Create(name));
    }
    
    [Theory]
    [InlineData(1,"Le nom doit contenir au moins 3 caracteres")]
    [InlineData(0,"Le nom ne doit pas etre vide")]
    [InlineData(101,"Le nom ne doit pas contenir plus de 100 caracteres")]
    public void Create_Should_ThrowException_Right_Expectation(int value, string message)
    {
        string name = new string('a', value);
        ArgumentException exception = Assert.Throws<ArgumentException>(() => TodoItem.Create(name));
        Assert.Equal(message, exception.Message);
    }
}