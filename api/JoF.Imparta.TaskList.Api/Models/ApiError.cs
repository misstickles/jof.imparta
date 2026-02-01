namespace JoF.Imparta.TaskList.Api.Models;

using System.Runtime.Serialization;

[Serializable]
[DataContract]
public sealed class ApiError
{
    [DataMember(EmitDefaultValue = false)]
    public object? Message { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string? Field { get; set; }

    public string? Type { get; set; }
}