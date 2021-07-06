using static System.Console;
namespace Visitor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var simple = new AdditionExpression(new MultiplicationExpression(new Value(2), new Value(2)), new Value(3));
            var ep = new ExpressionPrinter();

            ep.Visit(simple);
            WriteLine(ep);

            ReadKey();
        }
    }
}
