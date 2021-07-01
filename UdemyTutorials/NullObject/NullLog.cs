namespace NullObject
{
    public class NullLog : ILog
    {
        public int RecordLimit => RecordCount + 1;

        public int RecordCount { get; set; }

        public void LogInfo(string message)
        {
            RecordCount++;
        }
    }
}
