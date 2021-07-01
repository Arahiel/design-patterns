using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyweight
{
    public class Sentence
    {
        private readonly List<WordToken> _wordTokens = new List<WordToken>();
        private readonly string[] _words;

        public Sentence(string plainText)
        {
            _words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                if (_wordTokens.FirstOrDefault(x => x.Index == index) == null)
                {
                    _wordTokens.Add(new WordToken(index));
                }

                return _wordTokens.Single(x => x.Index == index);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _words.Length; i++)
            {
                var word = _words[i];
                sb.Append(_wordTokens.FirstOrDefault(x => x.Index == i) != null ? word.ToUpper() + " " : word + " ");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
            public readonly int Index;

            public WordToken(int index)
            {
                Index = index;
            }
        }
    }
}
