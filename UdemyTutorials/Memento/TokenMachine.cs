using System.Collections.Generic;

namespace Memento
{
    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            var token = new Token(value);
            Tokens.Add(token);
            return new Memento(new List<Token>(Tokens));
        }

        public Memento AddToken(Token token)
        {
            var t = new Token(token.Value);
            Tokens.Add(t);
            return new Memento(new List<Token>(Tokens));
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens;
        }
    }
}
