using Newtonsoft.Json.Linq;

namespace UtilitiesLib.Entities;

public record ModifiedJProperty(string PropertyName, JToken? OriginalValue, JToken? ModifiedValue, JTokenType JTokenType = JTokenType.None)
{
    public string PropertyName { get; set; } = PropertyName;
}