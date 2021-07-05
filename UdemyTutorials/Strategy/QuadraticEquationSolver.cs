using System;
using System.Numerics;

namespace Strategy
{
    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var discriminant = strategy.CalculateDiscriminant(a, b, c);
            var t1 = (-b + Complex.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b - Complex.Sqrt(discriminant)) / (2 * a);

            return Tuple.Create(t1, t2);
        }
    }
}
