using static System.Console;

namespace State
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });

            while(!(cl.Status.Equals("OPEN") || cl.Status.Equals("ERROR")))
            {
                var input = ReadKey().KeyChar;
                if(char.IsDigit(input))
                {
                    cl.EnterDigit(int.Parse(input.ToString()));
                }
            }

            ReadKey();
        }
    }
}
