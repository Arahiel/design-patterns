namespace Visitor
{
    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }
}
