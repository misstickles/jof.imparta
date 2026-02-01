namespace JoF.Imparta.TaskList.Api.Domain.Models;

public sealed class TaskItem
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
