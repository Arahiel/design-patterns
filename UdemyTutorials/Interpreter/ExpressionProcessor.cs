using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter
{
    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public class Token
        {
            public enum MyType
            {
                Plus,
                Minus,
                Integer,
                Variable
            }

            public MyType Type;
            public string Text { get; }

            public Token(MyType type, string text)
            {
                Type = type;
                Text = text;
            }

            public override string ToString()
            {
                return $"`{Text}`";
            }
        }

        public interface IElement
        {
            int Value { get; }
        }

        public class Integer : IElement
        {
            public Integer(int value)
            {
                Value = value;
            }

            public int Value { get; }
        }

        public class BinaryOperation : IElement
        {
            public IElement Left, Right;

            public enum Type
            {
                None, Addition, Subtraction
            }

            public Type MyType;

            public int Value
            {
                get
                {
                    switch (MyType)
                    {
                        case Type.Addition:
                            return Left.Value + Right.Value;
                        case Type.Subtraction:
                            return Left.Value - Right.Value;
                        case Type.None:
                            return Left.Value;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public List<Token> Lex(string input)
        {
            var result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.MyType.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.MyType.Minus, "-"));
                        break;
                    default:
                        var firstCharType = char.IsDigit(input[i]);

                        var sb = new StringBuilder(input[i].ToString());
                        switch (firstCharType)
                        {
                            case true:
                                for (var j = i + 1; j < input.Length; ++j)
                                {
                                    if (char.IsDigit(input[j]))
                                    {
                                        sb.Append(input[j]);
                                        ++i;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                result.Add(new Token(Token.MyType.Integer, sb.ToString()));
                                break;
                            default:
                                for (var j = i + 1; j < input.Length; ++j)
                                {
                                    if (char.IsLetter(input[j]))
                                    {
                                        sb.Append(input[j]);
                                        ++i;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                result.Add(new Token(Token.MyType.Variable, sb.ToString()));
                                break;
                        }
                        break;
                }
            }

            return result;
        }

        public bool IsValidExpression(List<Token> tokenList)
        {
            return tokenList.Where(x => x.Type == Token.MyType.Variable).All(x => x.Text.Length == 1 && Variables.ContainsKey(x.Text[0]));
        }

        public IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            var haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                switch (token.Type)
                {
                    case Token.MyType.Plus:
                        if (result.MyType != BinaryOperation.Type.None)
                        {
                            result.Left = new BinaryOperation { Left = result.Left, Right = result.Right, MyType = result.MyType };
                            result.Right = null;
                        }
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.MyType.Minus:
                        if (result.MyType != BinaryOperation.Type.None)
                        {
                            result.Left = new BinaryOperation { Left = result.Left, Right = result.Right, MyType = result.MyType };
                            result.Right = null;
                        }
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.MyType.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.MyType.Variable:
                        integer = new Integer(Variables[token.Text[0]]);
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }

        public int Calculate(string expression)
        {
            var tokenList = Lex(expression);
            return !IsValidExpression(tokenList) ? 0 : Parse(tokenList).Value;
        }

    }

}
