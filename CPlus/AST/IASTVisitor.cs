using CPlus.SematicChecker;

namespace CPlusAST
{
    public interface IASTVisitor<TResult>
    {
        TResult Visit(Program node, CompileEnviroment env);
        TResult Visit(ClassDecl node, CompileEnviroment env);
        TResult Visit(PublicModifier node, CompileEnviroment env);
        TResult Visit(PrivateModifier node, CompileEnviroment env);
        TResult Visit(FieldDecl node, CompileEnviroment env);
        TResult Visit(MethodDecl node, CompileEnviroment env);
        TResult Visit(VarDecl node, CompileEnviroment env);
        TResult Visit(ConstDecl node, CompileEnviroment env);
        TResult Visit(Assign node, CompileEnviroment env);
        TResult Visit(Return node, CompileEnviroment env);
        TResult Visit(CallMethodStmt node, CompileEnviroment env);
        TResult Visit(BinaryOp node, CompileEnviroment env);
        TResult Visit(UnaryOp node, CompileEnviroment env);
        TResult Visit(CallExpression node, CompileEnviroment env);
        TResult Visit(NewExpression node, CompileEnviroment env);
        TResult Visit(FieldAccess node, CompileEnviroment env);
        TResult Visit(IntLiteral node, CompileEnviroment env);
        TResult Visit(FloatLiteral node, CompileEnviroment env);
        TResult Visit(StringLiteral node, CompileEnviroment env);
        TResult Visit(BooleanLiteral node, CompileEnviroment env);
        TResult Visit(ThisLiteral node, CompileEnviroment env);
        TResult Visit(ID node, CompileEnviroment env);
        TResult Visit(IntType node, CompileEnviroment env);
        TResult Visit(FloatType node, CompileEnviroment env);
        TResult Visit(BooleanType node, CompileEnviroment env);
        TResult Visit(StringType node, CompileEnviroment env);
        TResult Visit(VoidType node, CompileEnviroment env);
        TResult Visit(ClassType node, CompileEnviroment env);
    }
}
