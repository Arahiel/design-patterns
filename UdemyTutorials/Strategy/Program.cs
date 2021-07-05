using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordinarySolver = new QuadraticEquationSolver(new OrdinaryDiscriminantStrategy());
            var realSolver = new QuadraticEquationSolver(new RealDiscriminantStrategy());

            var ordinaryResult = ordinarySolver.Solve(1, 1, 1);
            var realResult = realSolver.Solve(1, 1, 1);

            WriteLine(ordinaryResult);
            WriteLine(realResult);

            ReadKey();
        }
    }
}
