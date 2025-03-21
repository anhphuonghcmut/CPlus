namespace CPlus
{
    public abstract class CPlusAST
    {
        public abstract string Stringify(); 
    }

    public class ProgramDecl : CPlusAST
    {
        public IEnumerable<ClassDecl> ClassDecls { get; set; } = new List<ClassDecl>();

        public override string Stringify()
        {
            var stringifyClassList = new List<string>();
            foreach (var decl in ClassDecls)
            {
                stringifyClassList.Add(decl.Stringify());
            }

            return string.Join(Environment.NewLine, stringifyClassList);
    }
    }

    public class ClassDecl : CPlusAST
    {
        public ID ClassId { get; set; }
        public IEnumerable<MethodDecl> MethodDecls { get; set; } = new List<MethodDecl>();

        public override string Stringify()
        {
            var stringifyMethodList = new List<string>();
            foreach(var methodDecl in MethodDecls)
            {
                stringifyMethodList.Add(methodDecl.Stringify());
            }

            return $"(Class {ClassId.Stringify()}: [{string.Join(',', stringifyMethodList)}])";
        }
    }

    public class MethodDecl : CPlusAST
    {
        public string MethodModifier { get; set; }
        public BaseType MethodType { get; set; }
        public ID MethodId { get; set; }
        public override string Stringify()
        {
            return $"(Method {MethodModifier}: {MethodId.Stringify()} -> {MethodType.Stringify()})";
        }
    }

    public abstract class BaseType : CPlusAST
    {
    }

    public abstract class NumericType : BaseType
    {
    }

    public class IntType : NumericType
    {
        public override string Stringify()
        {
            return "int";
        }
    }

    public class FloatType : NumericType
    {
        public override string Stringify()
        {
            return "float";
        }
    }

    public class StringType : BaseType
    {
        public override string Stringify()
        {
            return "string";
        }
    }

    public class BooleanType : BaseType
    {
        public override string Stringify()
        {
            return "bool";
        }
    }

    public class VoidType : BaseType
    {
        public override string Stringify()
        {
            return "void";
        }
    }

    public class ID : CPlusAST
    {
        public ID(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public override string Stringify()
        {
            return Name;
        }
    }
}
