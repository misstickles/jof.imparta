using JoF.Imparta.TaskList.Api.Domain.Models;

namespace JoF.Imparta.TaskList.Api.Domain.Services;

public interface IProfileService
{
    /// <summary>
    /// Get the user's profile image string.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A <see cref="CommonApiResponse"/> with Base64 string of image</returns>
    Task<CommonApiResponse> GetByUserIdAsync(Guid userId);

    /// <summary>
    /// Upload a user's profile image string.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="imageBase64">The image base 64.</param>
    /// <param name="contentType">The content type.</param>
    /// <returns>A <see cref="CommonApiResponse"/> of uploaded profile.</returns>
    Task<CommonApiResponse> UploadAsync(Guid userId, string imageBase64, string contentType);
}
