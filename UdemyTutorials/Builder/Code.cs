using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class Code
    {
        public string ClassName;
        public Dictionary<string, string> Fields = new Dictionary<string, string>();

        public Code(string className)
        {
            ClassName = className;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");

            foreach (var field in Fields)
            {
                sb.AppendLine($"  public {field.Key} {field.Value};");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}