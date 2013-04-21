using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Test
{
    [TestFixture]
    public class JsonDemoGeneratorTest
    {
        private JsonDemoGenerator jsonDemoGenerator;

        [SetUp]
        private void Setup()
        {
            jsonDemoGenerator = new JsonDemoGenerator();
        }

        [Test]
        public void TestExtractJsonFromScheme()
        {
            const string filePath = "./schemas/出厂初始化-Input.json";
            JsonSchema schema = JsonSchema.Parse(File.ReadAllText(filePath));

            var jObject = jsonDemoGenerator.Run(schema);
            Debug.WriteLine(jObject);
        }
    }
}