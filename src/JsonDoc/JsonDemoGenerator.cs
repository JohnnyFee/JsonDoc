using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc
{
    /// <summary>
    /// Generate Json Demo according to Json Schema
    /// </summary>
    public class JsonDemoGenerator
    {
        private const string DefaultStringValue = "string value";
        private const int DefaultIntValue = 100;
        private const bool DefaultBoolValue = false;
        private const float DefaultFloatValue = 0.01f;

        /// <summary>
        ///     处理所有的Schema。
        /// </summary>
        private void ProcessSchemas()
        {
            var schmeaDirInfo = new DirectoryInfo("");
            IEnumerable<FileInfo> fileInfos = schmeaDirInfo.EnumerateFiles();

            var content = new StringBuilder();
            foreach (FileInfo fileInfo in fileInfos)
            {
                // TODO 
            }
        }

        public JToken Run(JsonSchema schema)
        {
            return Run(null, schema);
        }

        private JToken Run(string schemaKey, JsonSchema schema)
        {
            JToken token = null;
            switch (schema.Type)
            {
                case JsonSchemaType.Object:
                    token = new JObject();
                    foreach (var property in schema.Properties)
                    {
                        ((JObject) token).Add(property.Key, Run(property.Key, property.Value));
                    }
                    break;
                case JsonSchemaType.Array:
                    // token = new List<string> {"item1", "item2"};
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
                    token = DefaultStringValue;
                    break;
            }

            token = schema.Default ?? token;
            return token;
        }

        private JObject DeserializeSchema(string schemaFilePath)
        {
            string content = File.ReadAllText(schemaFilePath);
            JsonSchema schema = JsonSchema.Parse(schemaFilePath);

            while (schema.Properties.Count > 0)
            {
            }
            foreach (var property in schema.Properties)
            {
            }

            var root = new JObject();
            return root;
        }
    }
}