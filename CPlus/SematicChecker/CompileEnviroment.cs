using CPlus.Exceptions.StaticErrors;
using CPlus.Exceptions;
using CPlusAST;

namespace CPlus.SematicChecker
{
    public class CompileEnviroment
    {
        public SymbolTable SymbolTable { get; }
        public ClassSymbol CurrentClass { get; set; } // For resolving 'this'
        public MethodDecl CurrentMethod { get; set; } // For return type checking

        public CompileEnviroment()
        {
            SymbolTable = new SymbolTable();
        }
    }
    public class Symbol
    {
        public string Name { get; }
        public DataType Type { get; }
        public bool IsImmutable { get; }
        public bool IsPublic { get; }
        public bool IsStatic { get; }

        public Symbol(string name, DataType type, bool isImmutable = false, bool isPublic = true, bool isStatic = false)
        {
            Name = name;
            Type = type;
            IsImmutable = isImmutable;
            IsPublic = isPublic;
            IsStatic = isStatic; // for static access fields and methods, not used yet
        }
    }

    public class MethodSymbol : Symbol
    {
        public IEnumerable<VarDecl> Parameters { get; }
        public MethodSymbol(string name, DataType type, bool isPublic = true, IEnumerable<VarDecl> parameters = null) 
            : base(name, type, true, isPublic)
        {
            Parameters = parameters ?? new List<VarDecl>();
        }
    }

    // Present an identifier for class (when call static field or method)
    public class ClassTypeSymbol : Symbol
    {
        public ClassTypeSymbol(string name) : base(name, new VoidType())
        {
        }
    }

    public class ClassSymbol
    {
        public string Name { get; }
        public Dictionary<string, Symbol> Members { get; }
        public int Line { get; set; }
        public int Column { get; set; }

        public ClassSymbol(string name)
        {
            Name = name;
            Members = new Dictionary<string, Symbol>();
        }
    }

    public class SymbolTable
    {
        private readonly Stack<Dictionary<string, Symbol>> scopes = new Stack<Dictionary<string, Symbol>>();
        private readonly Dictionary<string, ClassSymbol> classes = new Dictionary<string, ClassSymbol>();

        public SymbolTable()
        {
            scopes.Push(new Dictionary<string, Symbol>());
        }

        public void EnterScope()
        {
            scopes.Push(new Dictionary<string, Symbol>());
        }

        public void ExitScope()
        {
            scopes.Pop();
        }

        public void AddClass(string name, ClassSymbol classSymbol)
        {
            if (classes.ContainsKey(name))
                throw new RedeclaredException(new Class(), name, classSymbol.Line, classSymbol.Column);
            classes[name] = classSymbol;
        }

        public void AddSymbol(Symbol symbol, int line, int column)
        {
            var currentScope = scopes.Peek();
            if (currentScope.ContainsKey(symbol.Name))
            {
                throw new RedeclaredException(symbol.IsImmutable ? new Constant() : new Variable(), symbol.Name, line, column);
            }
            currentScope[symbol.Name] = symbol;
        }

        public void AddParamSymbol(Symbol symbol, int line, int column)
        {
            var currentScope = scopes.Peek();
            if (currentScope.ContainsKey(symbol.Name))
            {
                throw new RedeclaredException(new Parameter(), symbol.Name, line, column);
            }
            currentScope[symbol.Name] = symbol;
        }

        public Symbol Lookup(string name, int line, int column)
        {
            foreach (var scope in scopes)
            {
                if (scope.ContainsKey(name))
                    return scope[name];
            }
            throw new UndeclaredException(new Variable(), name, line, column);
        }

        public ClassSymbol LookupClass(string name, int line, int column)
        {
            if (classes.ContainsKey(name))
                return classes[name];
            throw new UndeclaredException(new Class(), name, line, column);
        }
    }
}
