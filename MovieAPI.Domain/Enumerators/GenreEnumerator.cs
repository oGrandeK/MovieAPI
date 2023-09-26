using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MovieAPI.Domain.Enumerators;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GenreEnumerator
{
    [EnumMember(Value = "Action")]
    Action = 1,
    [EnumMember(Value = "Horror")]
    Horror = 2,
    [EnumMember(Value = "Comedy")]
    Comedy = 3,
    [EnumMember(Value = "Drama")]
    Drama = 4,
    [EnumMember(Value = "Adventure")]
    Adventure = 5
}