namespace JoF.Imparta.TaskList.Api.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Domain.Repositories;

public class ProfileService(ILogger<ProfileService> logger, ITaskRepository repository) : IProfileService
{
    /// <inheritdoc/>
    public async Task<CommonApiResponse> UploadAsync(Guid userId, string imageBase64, string contentType)
    {
        var errors = new List<CommonApiError>();
        var response = new CommonApiResponse
        {
            Errors = null,
            HasErrors = false
        };

        try
        {
            response.Result = await repository.CreateAsync(new ProfileItem
            {
                ContentType = contentType,
                ImageBase64 = imageBase64,
                UserId = userId
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            response.HasErrors = true;

            errors.Add(new CommonApiError
            {
                Message = $"Unknown Error"
            });
        }

        response.Errors = errors;

        return response;
    }

    /// <inheritdoc/>
    public async Task<CommonApiResponse> GetByUserIdAsync(Guid userId)
    {
        var errors = new List<CommonApiError>();
        var response = new CommonApiResponse
        {
            HasErrors = false,
            Errors = null,
        };

        try
        {
            response.Result = await repository.GetProfileImageAsync(userId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            response.HasErrors = true;

            errors.Add(new()
            {
                Message = "Unknown Error"
            });
        }

        response.Errors = errors;

        return response;
    }
}
