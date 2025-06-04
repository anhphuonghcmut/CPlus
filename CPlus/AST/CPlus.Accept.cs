using CPlus.SematicChecker;

namespace CPlusAST
{
    // Program
    public partial class Program
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Declarations
    public partial class ClassDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class FieldDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class MethodDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class VarDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class ConstDecl
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Modifiers
    public partial class PublicModifier
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class PrivateModifier
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Statements
    public partial class Assign
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class Return
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class CallMethodStmt
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Expressions
    public partial class BinaryOp
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class UnaryOp
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class CallExpression
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class NewExpression
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class FieldAccess
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Literals
    public partial class IntLiteral
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class FloatLiteral
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class StringLiteral
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class BooleanLiteral
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class ThisLiteral
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class ID
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    // Types
    public partial class IntType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class FloatType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class BooleanType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class StringType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class VoidType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class ClassType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }

    public partial class StaticAccessPrefixType
    {
        public override TResult Accept<TResult>(IASTVisitor<TResult> visitor, CompileEnviroment env)
        {
            return visitor.Visit(this, env);
        }
    }
}
