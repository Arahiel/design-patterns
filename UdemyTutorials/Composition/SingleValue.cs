using System.Collections;
using System.Collections.Generic;

namespace Composition
{
    public class SingleValue : IValueContainer
    {
        public int Value;

        public SingleValue()
        {
            
        }

        public SingleValue(int value)
        {
            Value = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}