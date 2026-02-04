namespace JoF.Imparta.TaskList.Api.Domain.Exceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(Exception ex) : base("The requested task cannot be found", ex)
    {
    }

    public TaskNotFoundException() : base("The requested task cannot be found")
    {
    }
}
