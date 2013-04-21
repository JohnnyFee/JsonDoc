﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc
{
    public class Program
    {
        private const string SchemaPath = "../Schemas";

        /// <summary>
        ///     处理所有的Schema。
        /// </summary>
        private void ProcessSchemas()
        {
            var schmeaDirInfo = new DirectoryInfo(SchemaPath);
            IEnumerable<FileInfo> fileInfos = schmeaDirInfo.EnumerateFiles();

            var content = new StringBuilder();
            foreach (FileInfo fileInfo in fileInfos)
            {
                // TODO 
            }
        }

        private JObject ExtractJsonFromScheme(string schemaKey, JsonSchema schema)
        {
            var jObject = new JObject();

            JToken token = null;
            switch (schema.Type)
            {
                case JsonSchemaType.Object:
                    token = new JObject();
                    foreach (var property in schema.Properties)
                    {
                        ((JObject) token).Add(property.Key, ExtractJsonFromScheme(property.Key, property.Value));
                    }
                    break;
                case JsonSchemaType.Array:
                    // token = new List<string> {"item1", "item2"};
                    break;
                case JsonSchemaType.Boolean:
                    token = false;
                    break;
                case JsonSchemaType.Float:
                    token = 1.2;
                    break;
                case JsonSchemaType.Integer:
                    token = 0;
                    break;
                case JsonSchemaType.String:
                    token = "string value";
                    break;
            }

            token = schema.Default ?? token;
            jObject.Add(schemaKey, JToken.FromObject(token));
            return jObject;
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

        public static void Main(string[] args)
        {
            var program = new Program();

            const string filePath = "./schemas/出厂初始化-Input.json";
            JsonSchema schema = JsonSchema.Parse(File.ReadAllText(filePath));

            Console.WriteLine(schema.Type);

            foreach (var property in schema.Properties)
            {
                Console.WriteLine(property.Key + " - " + property.Value.Type);
            }

            Console.ReadKey();
        }
    }
}