using JoF.Imparta.TaskList.Api.Domain.Models;

namespace JoF.Imparta.TaskList.Api.Domain.Services;

public class ProfileService : IProfileService
{
    /// <inheritdoc/>
    public Task<string> GetByUserIdAsync(Guid userId)
    {
        return Task.FromResult("done");
    }

    /// <inheritdoc/>
    public Task<ProfileItem> UpdloadAsync(Guid userId, byte[] imageBytes, string contentType)
    {
        throw new NotImplementedException();
    }
}
