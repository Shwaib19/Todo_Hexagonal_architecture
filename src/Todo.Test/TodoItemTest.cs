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
    public void Delete_Todo_ShouldReturnCorrectResult()
    {
        TodoItem todoItem = new TodoItem("test0");
        Assert.IsNotNull(todoItem);
        Assert.IsFalse(todoItem.IsDone);
        
    }

}