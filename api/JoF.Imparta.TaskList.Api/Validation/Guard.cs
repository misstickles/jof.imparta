namespace JoF.Imparta.TaskList.Api.Validation;

internal static class Guard
{
    internal static void ArgumentNotNull(object argument, string argumentName)
    {
        _ = argument ?? throw new ArgumentNullException(argumentName);
    }
}
