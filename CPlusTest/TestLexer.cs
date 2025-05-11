using Antlr4.Runtime;
using CPlus;
using CPlus.Exceptions;
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
        public void TestLegalToken()
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
        public void TestErrorToken()
        {
            var inputStream = new AntlrFileStream("./LexerTests/test2.txt");
            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);

            //tokens.Fill();
            Action act = () => tokens.Fill();
            act.Should().Throw<ErrorTokenException>();
        }

        [Test]
        public void TestUnclosedString()
        {
            var inputStream = new AntlrFileStream("./LexerTests/test3.txt");
            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);

            //tokens.Fill();
            Action act = () => tokens.Fill();
            act.Should().Throw<UncloseStringException>();
        }
    }
}