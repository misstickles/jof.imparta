using System.Runtime.Serialization;

namespace JoF.Imparta.TaskList.Api.Models;

[Serializable]
[DataContract]
public sealed class ApiResponse
{
    [DataMember]
    public bool HasErrors { get; set; }

    [DataMember]
    public int StatusCode { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public string? Path { get; set; }

    [DataMember]
    public string? Version { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public object? Result { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<ApiError>? Errors { get; set; }
}
