namespace JoF.Imparta.TaskList.Api.Domain.Services;

public interface IProfileService
{
    /// <summary>
    /// Get the user's profile image string.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>Base64 string of image</returns>
    Task<string> GetByUserIdAsync(Guid userId);

    /// <summary>
    /// Upload a user's profile image string.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="imageBase64String">The image base 64 string.</param>
    /// <returns>Success and/or exception if failed.</returns>
    Task<(string, Exception)> UpdloadAsync(Guid userId, string imageBase64String);
}
