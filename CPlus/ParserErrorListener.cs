using Antlr4.Runtime;

namespace CPlus
{
    public class ParserErrorListener : BaseErrorListener
    {
        public List<string> Errors { get; } = new List<string>();
        public bool HasErrors => Errors.Count > 0;

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.Add($"Line {line}:{charPositionInLine} {msg}");
        }
    }
}
