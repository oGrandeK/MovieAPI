using System.ComponentModel;
using System.Runtime.Serialization;

namespace MovieAPI.Domain.Enumerators;

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