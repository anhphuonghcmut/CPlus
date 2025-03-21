using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CPlus;
using FluentAssertions;

namespace CPlusTest
{
    public class TestParser
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var inputStream = new AntlrFileStream("./ParserTests/test1.txt");
            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);

            var parser = new CPlusParser(tokens);

            parser.RemoveErrorListeners();
            var errorListener = new ParserErrorListener();
            parser.AddErrorListener(errorListener);

            IParseTree tree = parser.program();

            errorListener.Errors.Count.Should().Be(0);
        }
    }
}