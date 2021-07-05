using System;

namespace Strategy
{
    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                return double.NaN;
            }

            return discriminant;
        }
    }
}
