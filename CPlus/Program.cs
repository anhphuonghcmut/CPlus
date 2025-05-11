using CPlus;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CPlusAST;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run <file_path>");
            return;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return;
        }

        try
        {
            var generateAST = GenerateAST(filePath);
            Console.WriteLine(generateAST.ToString());
        }
        catch (Exception ex) { 
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }

    public static AST GenerateAST(string filePath)
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
