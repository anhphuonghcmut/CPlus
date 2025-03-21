using Antlr4.Runtime;
using CPlus;
using FluentAssertions;

namespace CPlusTest
{
    public class TestLexer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var inputStream = new AntlrFileStream("./LexerTests/test1.txt");
            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);

            lexer.RemoveErrorListeners();
            var errorListener = new LexerErrorListener();
            lexer.AddErrorListener(errorListener);

            tokens.Fill();

            errorListener.Errors.Count.Should().Be(0);
        }

        [Test]
        public void Test2()
        {
            var inputStream = new AntlrFileStream("./LexerTests/test2.txt");
            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);

            lexer.RemoveErrorListeners();
            var errorListener = new LexerErrorListener();
            lexer.AddErrorListener(errorListener);

            tokens.Fill();

            errorListener.Errors.Count.Should().Be(1);
            errorListener.Errors[0].Should().Be("Line 3:13 token recognition error at: '1'");
        }
    }
}