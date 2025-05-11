﻿namespace CPlus.Exceptions
{
    public class ErrorTokenException : Exception
    {
        public ErrorTokenException(string text, int line, int col) : base($"Invalid token: {text} at {line}:{col}") { }
    }
}
