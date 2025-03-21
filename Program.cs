using CPlus;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;


var inputStream = new AntlrFileStream("./LexerTests/test1.txt");

var lexer = new CPlusLexer(inputStream);
var tokens = new CommonTokenStream(lexer);
var parser = new CPlusParser(tokens);

IParseTree tree = parser.program();
var visitor = new CPlusASTVisitor();
var program = visitor.Visit(tree);
Console.WriteLine(program.Stringify());