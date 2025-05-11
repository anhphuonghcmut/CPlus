namespace CPlus.Exceptions
{
    public class IllegalEscapeException : Exception
    {
        public IllegalEscapeException(string text, int line, int col) : base($"Illegal escape sequence: {text} at {line}:{col}") { }
    }
}
