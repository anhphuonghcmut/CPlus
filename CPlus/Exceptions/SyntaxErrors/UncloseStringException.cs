namespace CPlus.Exceptions
{
    public class UncloseStringException : Exception
    {
        public UncloseStringException(string text, int line, int col) : base($"Unclosed string: {text} at {line}:{col}") { }
    }
}
