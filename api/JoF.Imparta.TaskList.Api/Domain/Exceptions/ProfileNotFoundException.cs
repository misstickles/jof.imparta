namespace JoF.Imparta.TaskList.Api.Domain.Exceptions;

public class ProfileNotFoundException : Exception
{
    public ProfileNotFoundException(Exception ex) : base("The requested profile cannot be found", ex)
    {
    }

    public ProfileNotFoundException() : base("The requested profile cannot be found")
    {
    }
}
