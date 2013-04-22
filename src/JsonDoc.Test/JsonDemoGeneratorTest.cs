using System.IO;
using System.Text.RegularExpressions;
using JsonDoc.Core;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Test
{
    [TestFixture]
    public class JsonDemoGeneratorTest
    {
        [TestCase("./schemas/base.schema.json", "./schemas/base.json")]
        [TestCase("./schemas/array.schema.json", "./schemas/array.json")]
        public void TestExtractJsonFromScheme(string input, string output)
        {
            JsonSchema schema = JsonSchema.Parse(File.ReadAllText(input));
            JToken jObject = JsonDemoGenerator.Generate(schema);

            var regex = new Regex("\\s");

            string actual = JsonConvert.SerializeObject(jObject);
            actual = regex.Replace(actual, "");

            string exptected = File.ReadAllText(output);
            exptected = regex.Replace(exptected, "");
            Assert.AreEqual(actual, exptected);
        }
    }
}