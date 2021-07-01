namespace Builder
{
    public class CodeBuilder
    {
        private readonly Code _code;

        public CodeBuilder(string className)
        {
            _code = new Code(className);
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            _code.Fields.Add(fieldType, fieldName);
            return this;
        }

        public override string ToString()
        {
            return _code.ToString();
        }
    }
}