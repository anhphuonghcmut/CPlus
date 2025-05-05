namespace CPlus.Exceptions
{
    public class ErrorTokenException : Exception
    {
        public ErrorTokenException(string text) : base($"Invalid token: {text}") { }
    }
}
