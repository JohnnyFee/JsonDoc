using System;
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

        private void AddSchemeProperties()
        {
            
        }

        private JObject DeserializeSchema(string schemaFilePath)
        {
            string content = File.ReadAllText(schemaFilePath);
            var schema = JsonSchema.Parse(schemaFilePath);

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
            string schemaJson = program.ReadFromFile(filePath);
            JsonSchema schema = JsonSchema.Parse(schemaJson);

            Console.WriteLine(schema.Type);

            foreach (var property in schema.Properties)
            {
                Console.WriteLine(property.Key + " - " + property.Value.Type);
            }

            Console.ReadKey();
        }
    }
}