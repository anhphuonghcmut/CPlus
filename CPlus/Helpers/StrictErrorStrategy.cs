using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using CPlus.Exceptions;

public class StrictErrorStrategy : DefaultErrorStrategy
{
    public override void Recover(Parser recognizer, RecognitionException e)
    {
        throw new ParseException(
            $"Syntax error at line {e.OffendingToken.Line}, column {e.OffendingToken.Column}: {e.Message}",
            e
        );
    }

    public override IToken RecoverInline(Parser recognizer)
    {
        // Get expected token names
        string expectedTokens = GetExpectedTokens(recognizer).ToString(recognizer.Vocabulary);
        // Get found token name
        string foundToken = recognizer.CurrentToken.Text;
        throw new ParseException(
            $"Syntax error at line {recognizer.CurrentToken.Line}, column {recognizer.CurrentToken.Column}: " +
            $"expected {expectedTokens} but found '{foundToken}'"
        );
    }

    public override void Sync(Parser recognizer)
    {
        // Disable synchronization to prevent skipping tokens
    }

    public override void ReportError(Parser recognizer, RecognitionException e)
    {
        throw new ParseException(
            $"Syntax error at line {e.OffendingToken.Line}, column {e.OffendingToken.Column}: {e.Message}",
            e
        );
    }
}