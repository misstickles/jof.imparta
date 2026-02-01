namespace JoF.Imparta.TaskList.Api.Domain.Services;

public class ProfileService : IProfileService
{
    public Task<string> GetByUserIdAsync(Guid userId)
    {
        return Task.FromResult("done");
    }

    public Task<(string, Exception)> UpdloadAsync(Guid userId, string imageBase64String)
    {
        throw new NotImplementedException();
    }
}
