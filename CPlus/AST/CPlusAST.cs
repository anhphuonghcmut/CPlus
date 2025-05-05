namespace CPlusAST
{
    public abstract class AST
    {
        public abstract TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env);
    }

    public partial class Program : AST
    {
        public IEnumerable<ClassDecl> ClassDecls { get; set; }
    }

    public partial class ClassDecl : AST
    {
        public ID Name { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }

    public partial class Member : AST
    {
    }

    public partial class FieldDecl : Member
    {
    }

    public partial class MethodDecl : Member
    {
    }

    public partial class ID : AST
    {
    }
}
