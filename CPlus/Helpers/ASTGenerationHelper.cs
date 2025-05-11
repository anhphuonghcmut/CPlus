using Antlr4.Runtime;

namespace CPlus.Helpers
{
    public static class ASTGenerationHelper
    {
        public static (int, int) GetLineAndCol(ParserRuleContext ctx)
        {
            return (ctx.Start.Line, ctx.Start.Column);
        }
    }
}
