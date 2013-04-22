using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonDoc.Core
{
    /// <summary>
    ///     Json doc formaater.
    /// </summary>
    public class JsonDocFormatter
    {
        /// <summary>
        ///     转化为markdown格式。
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public static string AsMarkdown(JsonSchema schema)
        {
            var sb = new StringBuilder();

            // 生成表格
            sb.AppendLine(AsMarkdown(schema, 1).Trim());

            // 生成例子
            sb.AppendLine();
            sb.AppendLine("例子");
            sb.AppendLine();

            JToken demoToken = JsonDemoGenerator.Generate(schema);
            string demo = JsonConvert.SerializeObject(demoToken, Formatting.Indented);

            // 每一行前+4个空格，以适应markdown的code格式。
            var sr = new StringReader(demo);
            string line = sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                sb.AppendLine("    " + line);
                line = sr.ReadLine();
            }

            return sb.ToString();
        }

        private static string AsMarkdown(JsonSchema schema, Int32 level)
        {
            if (!schema.Type.Equals(JsonSchemaType.Object))
            {
                return null;
            }

            var sb = new StringBuilder();

            // 确定Title的级别
            string prefix = string.Empty;
            for (int i = 0; i < level; i++)
            {
                prefix += "##";
            }

            // 输出title
            sb.Append(prefix).Append(schema.Id == null ? "" : schema.Id + " ").AppendLine(schema.Title);

            // 如果是接口 输出描述
            if (schema.Id != null)
            {
                sb.AppendLine(schema.Description ?? string.Empty);
            }

            sb.AppendLine();

            // 输出表格头
            sb.AppendLine(@"|字段名|类型|标题|必须|说明|
|----|----|----|----|");

            // 输出属性行
            foreach (var property in schema.Properties)
            {
                // TODO process array
                if (property.Value.Type.Equals(JsonSchemaType.Object))
                {
                    property.Value.Description = string.Format("请参考 `{0}`", property.Value.Title);
                }

                JsonSchema value = property.Value;
                sb.AppendLine(string.Format("|{0}|{1}|{2}|{3}|{4}|", property.Key, value.Type, value.Title,
                                            value.Required, value.Description));
            }

            sb.AppendLine();

            // 输出Object属性

            IEnumerable<KeyValuePair<string, JsonSchema>> objectProperties =
                schema.Properties.Where(o => o.Value.Type.Equals(JsonSchemaType.Object));
            level++;
            foreach (var objectProperty in objectProperties)
            {
                sb.AppendLine(AsMarkdown(objectProperty.Value, level));
            }


            return sb.ToString();
        }
    }
}