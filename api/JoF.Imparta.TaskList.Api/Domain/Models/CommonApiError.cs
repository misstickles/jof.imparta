namespace JoF.Imparta.TaskList.Api.Domain.Models;

using System.Runtime.Serialization;

[Serializable]
[DataContract]
public sealed class CommonApiError
{
    [DataMember(EmitDefaultValue = false)]
    public object? Message { get; set; }
}