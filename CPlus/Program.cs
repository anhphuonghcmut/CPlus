using CPlus;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

internal class Program
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
            var inputStream = new AntlrFileStream(filePath);

            var lexer = new CPlusLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CPlusParser(tokens);

            IParseTree tree = parser.program();
            var visitor = new CPlusASTVisitor();
            var program = visitor.Visit(tree);
            Console.WriteLine(program.Stringify());
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}
