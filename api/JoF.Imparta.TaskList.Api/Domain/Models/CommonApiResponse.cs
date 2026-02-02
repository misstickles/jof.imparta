using System.Runtime.Serialization;

namespace JoF.Imparta.TaskList.Api.Domain.Models;

[Serializable]
[DataContract]
public sealed class CommonApiResponse
{
    [DataMember]
    public bool HasErrors { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public object? Result { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<CommonApiError>? Errors { get; set; }
}
