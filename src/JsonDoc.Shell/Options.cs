using System;
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

        [Option('m', "markdown", Required = false, HelpText = "格式化为markdown文件。")]
        public bool Marcdown { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
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

            if (LastParserState != null && LastParserState.Errors.Count > 0)
            {
                string errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
                    help.AddPreOptionsLine(errors);
                }
            }

            return help;
        }
    }
}