namespace JoF.Imparta.TaskList.Api.Test.Domain.Repositories;

using JoF.Imparta.TaskList.Api.Domain.Exceptions;
using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

[TestClass]
public class HashSetTaskRepositoryShould
{
    private readonly Guid userId = new("90a44306-a057-4c45-8f00-c2b246d76b6b");
    private readonly Guid taskId = new("49da3aec-7f91-4e59-b500-43ed64c33dbe");

    private readonly TaskItem taskItem;

    private readonly Mock<ILogger<ListTaskRepository>> loggerMock;

    private ListTaskRepository sut;

    public HashSetTaskRepositoryShould()
    {
        this.taskItem = new TaskItem
        {
            Description = "My First Description :)",
            Id = taskId,
            Title = "My First Dummy Task Title",
            UserId = this.userId
        };

        this.loggerMock = new Mock<ILogger<ListTaskRepository>>();
        this.sut = new ListTaskRepository(this.loggerMock.Object);
    }

    [TestInitialize]
    public void Init()
    {
        // a new database (list) for each test
        this.sut = new ListTaskRepository(this.loggerMock.Object);
    }

    [TestMethod]
    public void CreateANewTaskWithAllFields()
    {
        var created = this.sut.CreateAsync(this.taskItem);

        created.ShouldNotBeNull();

        var result = created.Result;
        result.ShouldNotBeNull();
        result.DateCreated.ShouldNotBeInRange(DateTime.UtcNow.AddSeconds(30), DateTime.UtcNow.AddSeconds(-30));
        result.Description.ShouldBe("My First Description :)");
        result.Id.ShouldBe(this.taskId);
        result.Status.ShouldBe(TaskStatus.Pending);
        result.Title.ShouldBe("My First Dummy Task Title");
        result.UserId.ShouldBe(this.userId);
    }

    [TestMethod]
    public void HaveTwoTasksWhenTwoAreAddedByUser()
    {
        var t = this.taskItem;
        this.sut.CreateAsync(t);

        t.Id = Guid.NewGuid();
        this.sut.CreateAsync(t);

        var all = this.sut.GetAllByUserIdAsync(this.userId);

        all.Result.Count().ShouldBe(2);
    }

    [TestMethod]
    public void HaveOneSampleTaskWhenNoneHaveBeenCreated()
    {
        var all = this.sut.GetAllByUserIdAsync(this.userId);
        all.Result.Count().ShouldBe(1);
        all.Result.First().Title.ShouldBe("Sample Task Title");
    }

    [TestMethod]
    public void DeleteTheGivenTask()
    {
        this.sut.CreateAsync(this.taskItem);

        var deleted = this.sut.DeleteAsync(this.taskId);

        deleted.Result.ShouldBeTrue();
    }

    [TestMethod]
    public void ThrowExceptionWhenRequestedTaskNotFound()
    {
        Func<Task> act = async () => await this.sut.GetById(new("66dfbdb9-3c7e-4ff8-a821-49cdfb41870a"));
        act.ShouldThrow<TaskNotFoundException>();
    }

    [TestMethod]
    public void UpdateRequestedTask()
    {
        this.sut.CreateAsync(this.taskItem);

        // create a new task, due to references...
        var t = new TaskItem
        {
            Description = this.taskItem.Description,
            Id = this.taskId,
            Title = "I'm new",
            UserId = this.userId
        };

        this.sut.UpdateAsync(t);

        var newTask = this.sut.GetById(this.taskId);
        newTask.Result.Title.ShouldBe("I'm new");
        newTask.Result.Description.ShouldBe("My First Description :)");
    }
}
