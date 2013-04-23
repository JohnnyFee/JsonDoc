using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Core
{
    /// <summary>
    ///     Generate Json Demo.
    /// </summary>
    public class JsonDemoGenerator
    {
        private const int DefaultIntValue = 100;
        private const bool DefaultBoolValue = false;
        private const float DefaultFloatValue = 0.01f;

        /// <summary>
        ///     Generate json demo for a schema object.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public static JToken Generate(JsonSchema schema)
        {
            JToken token = null;
            switch (schema.Type)
            {
                case JsonSchemaType.Object:
                    token = new JObject();
                    foreach (var property in schema.Properties)
                    {
                        ((JObject) token).Add(property.Key, Generate(property.Value));
                    }
                    break;
                case JsonSchemaType.Array:
                    token = new JArray();
                    // TODO 为什么items是List类型
                    foreach (JsonSchema item in schema.Items)
                    {
                        // Add tow element for array.
                        JToken element = Generate(item);
                        ((JArray) token).Add(element);
                        ((JArray) token).Add(element);
                    }
                    break;
                case JsonSchemaType.Boolean:
                    token = DefaultBoolValue;
                    break;
                case JsonSchemaType.Float:
                    token = DefaultFloatValue;
                    break;
                case JsonSchemaType.Integer:
                    token = DefaultIntValue;
                    break;
                case JsonSchemaType.String:
                    token = schema.Title;
                    break;
            }

            token = schema.Default ?? token;
            return token;
        }
    }
}