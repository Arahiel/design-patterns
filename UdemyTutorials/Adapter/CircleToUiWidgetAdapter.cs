using System;

namespace Adapter
{
    public class CircleToUiWidgetAdapter : IUiWidget
    {
        private readonly Circle _circle;

        public CircleToUiWidgetAdapter(Circle circle)
        {
            _circle = circle;
        }

        public void DrawWidget()
        {
            Console.WriteLine($"Drawing Circle! O at X:{_circle.X}, Y:{_circle.Y} with Radius:{_circle.Radius}");
        }
    }
}