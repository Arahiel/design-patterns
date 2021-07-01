using static System.Console;

namespace Observer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            var r1 = new Rat(game);
            WriteLine($"Rat 1 attack value: {r1.Attack}");

            var r2 = new Rat(game);
            WriteLine($"Rat 1 attack value: {r1.Attack}");
            WriteLine($"Rat 2 attack value: {r2.Attack}");

            r1.Dispose();
            WriteLine($"Rat 2 attack value: {r2.Attack}");

            var r3 = new Rat(game);
            WriteLine($"Rat 2 attack value: {r2.Attack}");
            WriteLine($"Rat 3 attack value: {r3.Attack}");

            var r4 = new Rat(game);
            WriteLine($"Rat 2 attack value: {r2.Attack}");
            WriteLine($"Rat 3 attack value: {r3.Attack}");
            WriteLine($"Rat 4 attack value: {r4.Attack}");


            ReadKey();
        }
    }
}
