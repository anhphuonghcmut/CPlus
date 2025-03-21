using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CPlus;
using FluentAssertions;

namespace CPlusTest
{
    public class TestAST
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var program = Program.GenerateAST("./ASTTests/test1.txt");
            program.Stringify().Should().Be($"(Class A: [(Method public: Test -> void),(Method private: abc -> int)]){Environment.NewLine}(Class ABC: [(Method public: Test13 -> void),(Method private: abc -> int),(Method public: abc -> bool)]){Environment.NewLine}(Class ABC123: [(Method public: Test13 -> void),(Method private: Test13 -> void),(Method private: abc -> int),(Method public: a12bc -> string)]){Environment.NewLine}(Class empty: [])");
        }
    }
}