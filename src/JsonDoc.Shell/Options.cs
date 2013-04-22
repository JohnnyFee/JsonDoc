using System.Text;
using CommandLine;
using CommandLine.Text;

namespace JsonDoc.Shell
{
    public class Options
    {
        [Option('s', "schema-folder", Required = false, HelpText = "schema文件目录,schema文件以.schema.json结尾。")]
        public string SchemaFolder { get; set; }

        [Option('o', "output-file", Required = false, HelpText = "输出的markdown文件路径。")]
        public string OutputFile { get; set; }

        [Option('m', "markdown", HelpText = "格式化为markdown文件。")]
        public bool Marcdown { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("JsonDoc 1.0");

            var help = new HelpText
                {
                    Heading = new HeadingInfo("JsonDoc", "1.0"),
                    Copyright = new CopyrightInfo("费强", 2012),
                    AdditionalNewLineAfterOption = true,
                    AddDashesToOption = true
                };
            help.AddPreOptionsLine("联系方式: djohnnyfee@gmail.com");
            help.AddPreOptionsLine("使用: jsondoc");
            help.AddOptions(this);
            return help;
        }
    }
}