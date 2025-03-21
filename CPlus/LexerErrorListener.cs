using Antlr4.Runtime;

namespace CPlus
{
    public class LexerErrorListener : IAntlrErrorListener<int>
    {
        public List<string> Errors { get; } = new List<string>();
        public bool HasErrors => Errors.Count > 0;

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.Add($"Line {line}:{charPositionInLine} {msg}");
        }
    }
}
