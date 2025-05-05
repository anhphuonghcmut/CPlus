namespace CPlus.Exceptions
{
    public class UncloseStringException : Exception
    {
        public UncloseStringException(string text) : base($"Unclosed string: {text}") { }
    }
}
