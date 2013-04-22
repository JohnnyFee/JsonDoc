using System.Diagnostics;
using System.IO;
using JsonDoc.Core;
using NUnit.Framework;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Test
{
    [TestFixture]
    public class JsonDocFormatterTest
    {
        // [TestCase("./schemas/base.schema.json")]
        // [TestCase("./schemas/array.schema.json")]
        [TestCase("./schemas/object.schema.json")]
        public void TestAsMarkdown(string jsonFilePath)
        {
            JsonSchema schema = JsonSchema.Parse(File.ReadAllText(jsonFilePath));
            string actual = JsonDocFormatter.AsMarkdown(schema);
            Debug.WriteLine(actual);
        }
    }
}