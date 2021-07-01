using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new ExpressionProcessor {Variables = {['x'] = 3}};
            WriteLine(ep.Calculate("1+2+3"));
            WriteLine(ep.Calculate("1+2+xy"));
            WriteLine(ep.Calculate("10-2-x"));
            var expression = "x-x-x";
            WriteLine($"{expression} = {ep.Calculate(expression)}");
            ReadKey();
        }
    }
}
