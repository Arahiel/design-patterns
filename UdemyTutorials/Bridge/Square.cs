namespace Bridge
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) => Name = "Square";
    }
}