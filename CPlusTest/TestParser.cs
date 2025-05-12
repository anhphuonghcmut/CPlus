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

        [TestCase("test1.txt", TestName = "TestCheckTestsShouldRun")]
        [TestCase("test2.txt", TestName = "TestComplex")]
        [TestCase("test3.txt", TestName = "TestMemberDecls")]
        public void TestCases(string filename)
        {
            var inputStream = new AntlrFileStream($"./ParserTests/{filename}");
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