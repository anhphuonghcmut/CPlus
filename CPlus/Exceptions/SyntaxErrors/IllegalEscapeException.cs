namespace CPlus.Exceptions
{
    public class IllegalEscapeException : Exception
    {
        public IllegalEscapeException(string text) : base($"Illegal escape sequence: {text}") { }
    }
}
