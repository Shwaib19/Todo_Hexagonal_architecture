using Todo.Domain;
namespace Todo.Test;

[TestClass]
public sealed class TodoTest
{
    [TestMethod]
    public void Create_Todo_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.IsNotNull(todoItem);
        Assert.AreEqual("test0", todoItem.Name);
        Assert.IsFalse(todoItem.IsDone);
    }

    [TestMethod]
    public void Update_Todo_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update("test1", true);
        Assert.IsNotNull(todoItem);
        Assert.AreEqual("test1", todoItem.Name);
        Assert.IsTrue(todoItem.IsDone);
    }

    [TestMethod]
    public void Update_Todo_WithOnlyName_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update("test1",null);
        Assert.IsNotNull("test1",todoItem.Name);
        Assert.IsFalse(todoItem.IsDone);
    }
    [TestMethod]
    public void Update_Todo_WithOnlyIsDone_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        todoItem.Update(null,true);
        Assert.AreEqual("test0",todoItem.Name);
        Assert.IsTrue(todoItem.IsDone);
    }

    [TestMethod]
    public void Status_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.AreEqual(todoItem.IsDone,todoItem.Status());
    }

    [TestMethod]
    public void Status_ShouldChangeIsDoneValue()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.IsFalse(todoItem.IsDone);
        todoItem.ChangeStatus();
        Assert.IsTrue(todoItem.IsDone);
        todoItem.ChangeStatus();
        Assert.IsFalse(todoItem.IsDone);
    }

    [TestMethod]
    public void Markdone_ShouldSetIsDoneToTrue()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.IsFalse(todoItem.IsDone);
        todoItem.MarkDone();
        Assert.IsTrue(todoItem.IsDone);
        todoItem.MarkDone();
        Assert.IsTrue(todoItem.IsDone);
    }
    
    [TestMethod]
    [DataRow(2,"Le nom doit contenir plus de 2 caracteres minimum")]
    [DataRow(0,"Le nom ne doit pas etre vide")]
    [DataRow(101,"Le nom ne doit pas contenir plus de 100 caracteres")]
    public void Create_Should_ThrowException_Right_Expectation(int value,string message)
    {
        string name = new string('a', value);
        Assert.Throws<ArgumentException>(() => TodoItem.Create(name),message);
    }


    
    
}