using JoF.Imparta.TaskList.Api.Domain.Models;

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
    /// <param name="imageBytes">The image byte array.</param>
    /// <param name="contentType">The content type.</param>
    /// <returns><see cref="ProfileItem"/> of uploaded profile.</returns>
    Task<ProfileItem> UpdloadAsync(Guid userId, byte[] imageBytes, string contentType);
}
