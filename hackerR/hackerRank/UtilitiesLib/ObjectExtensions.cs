using System.Reflection;
using Newtonsoft.Json.Linq;
using UtilitiesLib.Entities;

namespace UtilitiesLib
{
    public static class ObjectExtensions
    {
        public static object? GetPropertyValue(this object? @object, string propertyName)
        {
            if (@object == null) return null;

            var type = @object.GetType();
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(type.GetProperties());

            return propertyInfos.Where(i => i.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                .Select(info => info.GetValue(@object, null))
                .FirstOrDefault();
        }

        public static IEnumerable<ModifiedProperty> GetModifiedProperties(this object original, object objectWithChanges, string? propNamePrefix = null)
        {
            var typeOfOriginalObject = original.GetType();
            var typeOfNewObject = objectWithChanges.GetType();

            if (typeOfOriginalObject != typeOfNewObject)
                throw new InvalidOperationException($"Cannot compare objects of type {typeOfOriginalObject} with {typeOfNewObject}");

            var modifiedProperties = new List<ModifiedProperty>();
            foreach (var info in typeOfOriginalObject.GetProperties().ToList())
            {
                var value1 = original.GetPropertyValue(info.Name);
                var value2 = objectWithChanges.GetPropertyValue(info.Name);

                // ReSharper disable once RedundantNameQualifier
                if (object.Equals(value1, value2)) continue;
                if (value1 != null && value2 != null && (value1.GetType().IsNested || value2.GetType().IsNested))
                    modifiedProperties.AddRange(value1.GetModifiedProperties(value2, propNamePrefix: info.Name));
                else
                    modifiedProperties.Add(new ModifiedProperty(propNamePrefix != null ? $"{propNamePrefix}.{info.Name}" : info.Name, value1, value2));
            }

            return modifiedProperties;
        }

        public static IEnumerable<ModifiedJProperty> GetModifiedJsonProperties(this string originalJson, string modifiedJson, JsonLoadSettings? jsonLoadSettings = null)
        {
            JToken obj1JToken, obj2JToken;
            try
            {
                obj1JToken = JToken.Parse(originalJson, settings: jsonLoadSettings);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException($"{nameof(originalJson)} is not a valid json.{Environment.NewLine}Error when parsing: {ex.Message}");
            }

            try
            {
                obj2JToken = JToken.Parse(modifiedJson, settings: jsonLoadSettings);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException($"{nameof(modifiedJson)} is not a valid json.{Environment.NewLine}Error when parsing: {ex.Message}");
            }

            return obj1JToken.FindModifications(obj2JToken)
                .ToHashSet();
        }

        private static IEnumerable<ModifiedJProperty> FindModifications(this JToken original, JToken modified)
        {
            var diffs = new List<ModifiedJProperty>();
            if (JToken.DeepEquals(original, modified)) return diffs;

            var current = original as JObject;
            var model = modified as JObject;

            current ??= new JObject();
            model ??= new JObject();

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (original.Type)
            {
                case JTokenType.Object:
                {
                    #region : removed keys :

                    var keysOnlyInOriginal = current.Properties()
                        .Select(c => c.Path)
                        .Except(model.Properties().Select(c => c.Path));

                    diffs.AddRange(keysOnlyInOriginal.Select(oKey => new ModifiedJProperty(oKey, original[oKey], null, original.Type)));

                    #endregion

                    #region : added keys:

                    var keysOnlyInModified = model.Properties()
                        .Select(c => c.Path)
                        .Except(current.Properties().Select(c => c.Path));

                    diffs.AddRange(keysOnlyInModified.Select(mKey => new ModifiedJProperty(mKey, null, modified[mKey], modified.Type)));

                    #endregion

                    #region : no changes :

                    var unModifiedKeys = current.Properties()
                        .Where(c => JToken.DeepEquals(c.Value, modified[c.Name]))
                        .Select(c => c.Name);

                    #endregion

                    #region : modified keys including recursive calls :

                    var modifiedKeys = current.Properties()
                        .Select(c => c.Name)
                        .Except(keysOnlyInOriginal)
                        .Except(unModifiedKeys);
                    foreach (var key in modifiedKeys)
                    {
                        var foundDifferencesForNestedJson = FindModifications(current[key], model[key]);
                        if (!foundDifferencesForNestedJson.Any()) continue;
                        foundDifferencesForNestedJson.ForEach(mp =>
                        {
                            diffs.Add(new ModifiedJProperty(mp.PropertyName, mp.OriginalValue, mp.ModifiedValue, mp.JTokenType));
                        });
                    }

                    #endregion
                }
                    break;
                default:
                    diffs.Add(new ModifiedJProperty(original.Path, original, modified, original.Type == JTokenType.Null ? modified.Type : original.Type));
                    break;
            }

            return diffs;
        }
    }
}