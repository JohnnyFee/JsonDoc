using System;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using JsonDoc.Core;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Shell
{
    public class Program
    {
        /// <summary>
        ///     Generate json demo list for every schema json file in a folder.
        /// </summary>
        public static string AsMarkdown(DirectoryInfo directory)
        {
            IQueryable<FileInfo> fileInfos =
                directory.EnumerateFiles()
                         .AsQueryable()
                         .Where(fileInfo => fileInfo.Name.ToLower().EndsWith("schema.json"));

            if (!fileInfos.Any())
            {
                Console.WriteLine("未找到任何schema文件。");
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (FileInfo fileInfo in fileInfos)
            {
                sb.AppendLine(AsMarkdown(fileInfo));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Generate json demo for a file.
        /// </summary>
        private static string AsMarkdown(FileInfo file)
        {
            Console.WriteLine("解析文件\"{0}\"...", file.Name);
            try
            {
                JsonSchema schema = JsonSchema.Parse(File.ReadAllText(file.FullName));
                return JsonDocFormatter.AsMarkdown(schema);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return string.Empty;
            }
        }

        public static void Main(string[] args)
        {
//            args =
//                "jsondoc -s D:/project/GuiZhouAbc2/doc/数据规范 -o D:/project/GuiZhouAbc2/doc/数据规范/index.md -m ".Split(' ');
            var options = new Options();
            bool success = Parser.Default.ParseArguments(args, options);
            if (!success)
            {
                Console.WriteLine(options.GetUsage());
                return;
            }

            if (options.Marcdown)
            {
                string markdown = AsMarkdown(new DirectoryInfo(options.SchemaFolder ?? "./"));
                if (!string.IsNullOrEmpty(markdown))
                {
                    File.WriteAllText(options.OutputFile ?? "doc.md", markdown);
                }
            }

            // Console.ReadLine();
        }
    }
}