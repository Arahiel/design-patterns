using System;

namespace Strategy
{
    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
    }
}
