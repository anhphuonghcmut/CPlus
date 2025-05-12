using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using CPlus;
using CPlusAST;
using FluentAssertions;
using NUnit.Framework.Constraints;

namespace CPlusTest
{
    public class TestAST
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestClasses()
        {
            var path = "./ASTTests/test1.txt";
            var ast = GenerateAST(path);
            var expect = new CPlusAST.Program(new List<ClassDecl>()
            {
                new ClassDecl(new ID("a"), new List<Member>()),
                new ClassDecl(new ID("b"), new List<Member>()),
                new ClassDecl(new ID("c"), new List<Member>())
            });
            ast.ToString().Should().Be(expect.ToString());
        }

        [Test]
        public void TestFieldAndMethodDecls()
        {
            var path = "./ASTTests/test2.txt";
            var ast = GenerateAST(path);
            var expect = new CPlusAST.Program(new List<ClassDecl>()
            {
                new ClassDecl(new ID("a"), new List<Member>()
                {
                    new FieldDecl(new PrivateModifier(), new VarDecl(new IntType(), new ID("a"), null)),
                    new FieldDecl(new PrivateModifier(), new VarDecl(new FloatType(), new ID("b"), null)),
                    new MethodDecl(new PrivateModifier(), new VoidType(), new ID("test"), new List<VarDecl>(), new List<StoreDecl>(), new List<Statement>()),
                    new FieldDecl(new PrivateModifier(), new ConstDecl(new StringType(), new ID("abc"), null)),
                    new FieldDecl(new PublicModifier(), new VarDecl(new BooleanType(), new ID("cba"), null)),
                    new MethodDecl(new PublicModifier(), new IntType(), new ID("test2"), new List<VarDecl>(), new List<StoreDecl>(), new List<Statement>()),
                    new FieldDecl(new PublicModifier(), new ConstDecl(new StringType(), new ID("oooo"), null)),
                })
            });
            ast.ToString().Should().Be(expect.ToString());
        }

        [Test]
        public void TestVarDecls()
        {
            var path = "./ASTTests/test3.txt";
            var ast = GenerateAST(path);
            var expect = new CPlusAST.Program(new List<ClassDecl>()
            {
                new ClassDecl(new ID("a"), new List<Member>()
                {
                    new MethodDecl(new PrivateModifier(), new VoidType(), new ID("test"), new List<VarDecl>(), new List<StoreDecl>() {
                        new ConstDecl(new IntType(), new ID("a"), new FieldAccess(new NewExpression(new ID("AST")), new ID("abc"))),
                        new VarDecl(new FloatType(), new ID("b"), new CallExpression(new ID("abc"), new ID("call"), new List<Expression>()
                        {
                            new IntLiteral(1),
                            new FloatLiteral(2.2f),
                            new BinaryOp("+", new IntLiteral(6), new BooleanLiteral(false)),
                            new BinaryOp("-", new CallExpression(new NewExpression(new ID("AST")), new ID("abc"), new List <Expression>() { new StringLiteral("string") }), new IntLiteral(7))
                        }))
                    }, new List<Statement>()),
                })
            });
            ast.ToString().Should().Be(expect.ToString());
        }

        [Test]
        public void TestStatements()
        {
            var path = "./ASTTests/test4.txt";
            var ast = GenerateAST(path);
            var expect = new CPlusAST.Program(new List<ClassDecl>()
            {
                new ClassDecl(new ID("a"), new List<Member>()
                {
                    new MethodDecl(new PrivateModifier(), new VoidType(), new ID("test"), new List<VarDecl>(), new List<StoreDecl>() {
                        new ConstDecl(new IntType(), new ID("a"), new FieldAccess(new NewExpression(new ID("AST")), new ID("abc"))),
                    }, 
                    new List<Statement>()
                    {
                        new Assign(new ID("b"), new CallExpression(new ID("abc"), new ID("call"), new List<Expression>()
                        {
                            new IntLiteral(1),
                            new FloatLiteral(2.2f),
                            new BinaryOp("+", new IntLiteral(6), new BooleanLiteral(false)),
                            new BinaryOp("-", new CallExpression(new NewExpression(new ID("AST")), new ID("abc"), new List <Expression>() { new StringLiteral("string") }), new IntLiteral(7))
                        })),
                        new CallMethodStmt(new ID("mm"), new ID("call"), new List<Expression>()
                        {
                            new IntLiteral(1),
                            new FloatLiteral(1.2f)
                        }),
                        new CallMethodStmt(
                            new CallExpression(new ID("mm"), new ID("call"), new List<Expression>()
                            {
                                new IntLiteral(1),
                                new StringLiteral("123")
                            }), 
                            new ID("func"), 
                            new List<Expression>()
                            {
                                new BooleanLiteral(true)
                            }
                        ),
                        new Return(new IntLiteral(100)),
                        new Return(new BooleanLiteral(true)),
                        new Return(null)
                    }),
                })
            });
            ast.ToString().Should().Be(expect.ToString());
        }

        private AST GenerateAST(string filePath)
        {
            var inputStream = new AntlrFileStream(filePath);

            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CPlusParser(tokens);
            // Throw error if rules aren't respect
            parser.ErrorHandler = new StrictErrorStrategy();

            IParseTree tree = parser.program();
            var visitor = new CPlusASTVisitor();
            var program = visitor.Visit(tree);
            return program;
        }
    }
}