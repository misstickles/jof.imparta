namespace JoF.Imparta.TaskList.Api.Domain.Models;

public class ProfileItem
{
    public Guid UserId { get; set; }

    public string ImageBase64 { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;
}
