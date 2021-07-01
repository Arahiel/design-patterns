using System.Collections.Generic;

namespace Memento
{
    public class Memento
    {
        public List<Token> Tokens { get; }

        public Memento(List<Token> tokens)
        {
            Tokens = tokens;
        }
    }
}
