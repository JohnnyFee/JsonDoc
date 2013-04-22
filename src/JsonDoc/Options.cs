using System.Text;
using CommandLine;
using CommandLine.Text;

namespace JsonDoc.Shell
{
    public class Options
    {
        [Option('s', "schema-file", Required = true, HelpText = "The schema file path for generating file.")]
        public string SchemaFile { get; set; }

        [Option('m', "markdown", HelpText = "To generate document in markdown format for the schema file.")]
        public bool Marcdown { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("JsonDoc 1.0");

            var help = new HelpText
            {
                Heading = new HeadingInfo("JsonDoc", "1.0"),
                Copyright = new CopyrightInfo("JohnnyFee", 2012),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Cotact me: djohnnyfee@gmail.com");
            help.AddPreOptionsLine("Usage: jsondoc");
            help.AddOptions(this);
            return help;
        }
    }
}