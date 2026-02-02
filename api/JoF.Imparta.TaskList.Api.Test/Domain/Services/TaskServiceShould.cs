namespace JoF.Imparta.TaskList.Api.Test.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Exceptions;
using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Domain.Repositories;
using JoF.Imparta.TaskList.Api.Domain.Services;

using Microsoft.Extensions.Logging;

using Moq;

using Shouldly;

[TestClass]
public class TaskServiceShould
{
    private readonly Guid userId = new Guid("df5289a0-8f3f-4b94-a29c-ef7a1ecc5092");
    private readonly Guid taskId = new Guid("8d1a0684-edea-4e34-946a-2ee5d23de0b5");

    private readonly Mock<ILogger<ListTaskRepository>> loggerMock;
    private readonly Mock<ITaskRepository> taskRepositoryMock;

    private readonly TaskService sut;

    public TaskServiceShould()
    {
        this.loggerMock = new Mock<ILogger<ListTaskRepository>>();
        this.taskRepositoryMock = new Mock<ITaskRepository>();

        var results = new TaskItem
        {
            DateCreated = DateTime.UtcNow,
            Description = "My Description",
            Id = this.taskId,
            Status = TaskStatus.Completed,
            Title = "My Title",
            UserId = this.userId
        };

        this.taskRepositoryMock
            .Setup(r => r.CreateAsync(It.IsAny<TaskItem>()))
            .ReturnsAsync(results);

        this.sut = new TaskService(loggerMock.Object, taskRepositoryMock.Object);
    }

    [TestMethod]
    public void ReturnNoErrorsWhenCreateNewTask()
    {
        var created = this.sut.CreateAsync(this.userId, "", "");
        created.ShouldNotBeNull();

        var response = created.Result;
        response.ShouldBeOfType<CommonApiResponse>();
        response.Errors?.ShouldBeNull();
        response.HasErrors.ShouldBeFalse();            

        var result = (TaskItem)response.Result!;
        result.Id.ShouldBe(this.taskId);
    }

    [TestMethod]
    public void ThrowTaskNotFoundExceptionWhenDeleteByWrongUser()
    {
        var newUserId = new Guid("f60a0f85-0974-492c-bfa1-c294d7e3ab9d");

        var created = this.sut.CreateAsync(this.userId, "", "");

        var deleted = this.sut.DeleteByIdAsync(this.taskId, newUserId);

        Func<Task> act = async () => await this.sut.DeleteByIdAsync(this.taskId, newUserId);
        act.ShouldThrow<TaskNotFoundException>();
    }
}
