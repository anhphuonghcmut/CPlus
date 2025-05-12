using CPlus;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CPlusAST;
using CPlus.SematicChecker;
using CPlus.Exceptions.StaticErrors;
using CPlus.Exceptions;

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
            var generatedAST = GenerateAST(filePath);
            var checker = new SematicChecker();
            checker.Visit(generatedAST, new CompileEnviroment());
        }
        catch (ParseException e)
        {
            Console.WriteLine($"Syntax error: {e.Message}");
            return;
        }
        catch (ErrorTokenException e)
        {
            Console.WriteLine($"Lexer error: {e.Message}");
            return;
        }
        catch (RedeclaredException e)
        {
            Console.WriteLine($"Redeclaration error: {e.Message}");
            return;
        }
        catch (UndeclaredException e)
        {
            Console.WriteLine($"Undeclared error: {e.Message}");
            return;
        }
        catch (CannotAssignToConstantException e)
        {
            Console.WriteLine($"Constant assignment error: {e.Message}");
            return;
        }
        catch (TypeMismatchInStatementException e)
        {
            Console.WriteLine($"Type mismatch in statement: {e.Message}");
            return;
        }
        catch (TypeMismatchInExpressionException e)
        {
            Console.WriteLine($"Type mismatch in expression: {e.Message}");
            return;
        }
        catch (IllegalConstantExpressionException e)
        {
            Console.WriteLine($"Illegal constant expression: {e.Message}");
            return;
        }
        catch (IllegalMemberAccessException e)
        {
            Console.WriteLine($"Illegal member access: {e.Message}");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return;
        }
        Console.WriteLine("Compiled successfully!");
        Console.ReadKey();
    }

    public static CPlusAST.Program GenerateAST(string filePath)
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
        return (CPlusAST.Program)program;
    }
}
