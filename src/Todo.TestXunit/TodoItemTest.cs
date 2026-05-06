using Todo.Domain;
using Moq;
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
    public void Create_Should_Throw_Exception_When_NameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => TodoItem.Create(null));
        
    }

    [Fact]
    public void Create_Should_Return_TodoItem()
    {
        Assert.IsType<TodoItem>(TodoItem.Create("test0"));
    }

    [Fact]
    public void Create_Todo_Should_ReturnCorect_Default_Value()
    {
        TodoItem todoItem = new TodoItem("test0");
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
    public void Create_Should_ThrowException_Right_Exception(int value, string message)
    {
        string name = new string('a', value);
        ArgumentException exception = Assert.Throws<ArgumentException>(() => TodoItem.Create(name));
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void Factorial_Should_Throw_OutOfRangeException_When_IsNegative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Mathe.Factorial(-2));
    }

    [Fact]
    public void Factorial_Should_Return_1_Given_0()
    {
        Assert.Equal(1, Mathe.Factorial(0));
    }
    [Fact]
    public void Factorial_Should_Return_1_Given_1()
    {
        Assert.Equal(1, Mathe.Factorial(1));
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    public void Factorial_Should_Return_Right_Value(int value, int expected)
    {
        Assert.Equal(Mathe.Factorial(value), expected);
    }

    [Fact]
    public void Factorial_Should_Throw_OverflowException_When_GreaterThan_20()
    {
        Assert.Throws<OverflowException>(() => Mathe.Factorial(21));
    }

    [Fact]
    public void Factorial_Should_Return_Value_When_WorkingToday()
    {
        var sut = new MatheService(new FakeExternalServiceWorkingToday(true));
        Assert.Equal(1, sut.Factorial(0));
    }
    [Fact]
    public void Factorial_Should_Throw_When_Not_WorkingToday()
    {
        var sut = new MatheService( new FakeExternalServiceWorkingToday(false));
        Assert.Throws<Exception>(() => sut.Factorial(0));
    }
    
    [Fact]
    public void Factorial_Should_Return_Value_When_WorkingToday2()
    {
        var mockExternalService = new Mock<IExternalService>();
        mockExternalService.Setup( service => service.WorkToday()).Returns(true);
        var sut = new MatheService(mockExternalService.Object);
        Assert.Equal(1, sut.Factorial(0));
    }
    [Fact]
    public void Factorial_Should_Throw_When_Not_WorkingToday2()
    {
        var mockExternalService = new Mock<IExternalService>();
        mockExternalService.Setup( service => service.WorkToday()).Returns(false);
        var sut = new MatheService(mockExternalService.Object);
        Assert.Throws<Exception>(() => sut.Factorial(0));
    }
}