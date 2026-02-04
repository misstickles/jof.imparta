namespace JoF.Imparta.TaskList.Api.Domain.Guards;

internal static class Guard
{
    internal static void ArgumentNotNull(object argument, string argumentName)
    {
        _ = argument ?? throw new ArgumentNullException(argumentName);
    }
}
