namespace CPlusAST
{
    public partial class Program
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }

    public partial class ClassDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Member
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }




    public partial class ID
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
