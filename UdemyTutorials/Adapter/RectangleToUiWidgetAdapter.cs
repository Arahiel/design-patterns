using System;

namespace Adapter
{
    public class RectangleToUiWidgetAdapter : IUiWidget
    {
        private readonly Rectangle _rectangle;

        public RectangleToUiWidgetAdapter(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public void DrawWidget()
        {
            Console.WriteLine(
                $"Drawing Rectangle! |_| at X:{_rectangle.X}, Y:{_rectangle.Y} with Width:{_rectangle.Width} and Height: {_rectangle.Height}");
        }
    }
}