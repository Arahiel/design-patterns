using static System.Console;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            WriteLine(string.Join(",", tree.PreOrder));
            ReadKey();
        }
    }
}
