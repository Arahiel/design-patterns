using System.Collections.Generic;

namespace Iterator
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                IEnumerable<Node<T>> Traverse<T>(Node<T> current)
                {
                    yield return current;
                    if (current.Left != null)
                    {
                        foreach (var left in Traverse<T>(current.Left))
                        {
                            yield return left;
                        }
                    }
                    if (current.Right != null)
                    {
                        foreach (var right in Traverse<T>(current.Right))
                        {
                            yield return right;
                        }
                    }
                }

                foreach (var node in Traverse<T>(this))
                {
                    yield return node.Value;
                }
            }
        }
    }
}
