using System;
using CommandLine;
using JsonDoc.Core;

namespace JsonDoc.Shell
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var options = new Options();
            bool success = Parser.Default.ParseArguments(args, options);
            if (!success)
            {
                Console.WriteLine(options.GetUsage());
            }

            string schemaFolder = options.SchemaFile;
            if (string.IsNullOrEmpty(schemaFolder))
            {
                schemaFolder = "./";
            }

            foreach (var VARIABLE in schemaFolder)
            {
                
            }

            var formatter = new JsonDocFormatter();
            if (options.Marcdown)
            {
                // formatter.AsMarkdown()
            }
            Console.ReadKey();
        }
    }
}