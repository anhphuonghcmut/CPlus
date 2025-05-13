namespace CPlusAST
{
    public partial class Program
    {
        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, ClassDecls.Select(cd => cd.ToString()))}";
        }
    }

    public partial class ClassDecl
    {
        public override string ToString()
        {
            return $"ClassDecl({Name?.ToString()}, {string.Join(", ", Members.Select(cd => cd.ToString()))})";
        }
    }

    public partial class PublicModifier
    {
        public override string ToString()
        {
            return "Public";
        }
    }

    public partial class PrivateModifier
    {
        public override string ToString()
        {
            return "Private";
        }
    }

    public partial class FieldDecl
    {
        public override string ToString()
        {
            return $"FieldDecl({FieldModifier?.ToString()}, {Decl?.ToString()})";
        }
    }

    public partial class MethodDecl
    {
        public override string ToString()
        {
            return $"MethodDecl({MethodModifier?.ToString()}, {Name}, {ReturnType.ToString()}, " +
                $"[{string.Join(", ", Params.Select(cd => cd.ToString()))}], " +
                $"[{string.Join(", ", Decls.Select(cd => cd.ToString()))}], " +
                $"[{string.Join(", ", Statements.Select(cd => cd.ToString()))}])";
        }
    }

    public partial class VarDecl
    {
        public override string ToString()
        {
            return $"VarDecl({DataType?.ToString()}, {Name?.ToString()}, {Value?.ToString()})";
        }
    }

    public partial class ConstDecl
    {
        public override string ToString()
        {
            return $"ConstDecl({DataType?.ToString()}, {Name?.ToString()}, {Value?.ToString()})";
        }
    }

    public partial class BinaryOp
    {
        public override string ToString()
        {
            return $"BinaryOp({Op?.ToString()}, {Left?.ToString()}, {Right?.ToString()})";
        }
    }

    public partial class UnaryOp
    {
        public override string ToString()
        {
            return $"UnaryOp({Op?.ToString()}, {Body?.ToString()})";
        }
    }

    public partial class CallExpression
    {
        public override string ToString()
        {
            return $"CallExpression({Obj?.ToString()}, {Method?.ToString()}, [{string.Join(", ", Params.Select(cd => cd.ToString()))}])";
        }
    }

    public partial class NewExpression
    {
        public override string ToString()
        {
            return $"NewExpression({ClassName?.ToString()})";
        }
    }

    public partial class FieldAccess
    {
        public override string ToString()
        {
            return $"FieldAccess({Obj?.ToString()}, {FieldName?.ToString()})";
        }
    }

    public partial class IntLiteral
    {
        public override string ToString()
        {
            return $"IntLiteral({Value})";
        }
    }

    public partial class FloatLiteral
    {
        public override string ToString()
        {
            return $"FloatLiteral({Value})";
        }
    }

    public partial class StringLiteral
    {
        public override string ToString()
        {
            return $"StringLiteral({Value})";
        }
    }

    public partial class BooleanLiteral
    {
        public override string ToString()
        {
            return $"BooleanLiteral({Value})";
        }
    }

    public partial class ThisLiteral
    {
        public override string ToString()
        {
            return $"This()";
        }
    }

    public partial class Assign
    {
        public override string ToString()
        {
            return $"Assign({LHS?.ToString()}, {Expression?.ToString()})";
        }
    }

    public partial class Return
    {
        public override string ToString()
        {
            return $"Return({Expression?.ToString()})";
        }
    }

    public partial class CallMethodStmt
    {
        public override string ToString()
        {
            return $"CallMethod({Obj?.ToString()}, {Method?.ToString()}, [{string.Join(", ", Params.Select(cd => cd.ToString()))}])";
        }
    }

    public partial class ID
    {
        public override string ToString()
        {
            return $"ID({Name})";
        }
    }

    public partial class IntType
    {
        public override string ToString()
        {
            return "IntType";
        }
    }

    public partial class FloatType
    {
        public override string ToString()
        {
            return "FloatType";
        }
    }

    public partial class BooleanType
    {
        public override string ToString()
        {
            return "BooleanType";
        }
    }

    public partial class StringType
    {
        public override string ToString()
        {
            return "StringType";
        }
    }

    public partial class VoidType
    {
        public override string ToString()
        {
            return "VoidType";
        }
    }

    public partial class ClassType
    {
        public override string ToString()
        {
            return $"ClassType({ClassName.Name})";
        }
    }
}
