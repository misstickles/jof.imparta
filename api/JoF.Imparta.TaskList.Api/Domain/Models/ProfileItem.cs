namespace JoF.Imparta.TaskList.Api.Domain.Models;

public class ProfileItem
{
    public Guid UserId { get; set; }

    public byte[] ImageBytes { get; set; } = [];

    public string ContentType { get; set; } = string.Empty;
}
