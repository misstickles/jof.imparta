namespace JoF.Imparta.TaskList.Api.Domain.Models;

public sealed class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
