using CPlus.Exceptions;
using CPlus.Exceptions.StaticErrors;
using CPlus.Helpers;
using CPlusAST;

namespace CPlus.SematicChecker
{
    public class SematicChecker : IASTVisitor<DataType>
    {
        public DataType Visit(CPlusAST.Program node, CompileEnviroment env)
        {
            var getEnvVisitor = new GetEnv();
            getEnvVisitor.Visit(node, env);
            // Handle class members
            foreach(var classDecl in node.ClassDecls)
            {
                classDecl.Accept(this, env);
            }
            return null;
        }

        public DataType Visit(ClassDecl node, CompileEnviroment env)
        {
            env.CurrentClass = env.SymbolTable.LookupClass(node.Name.Name, node.Line, node.Column);
            foreach (var mem in node.Members) { 
                mem.Accept(this, env);
            }
            env.CurrentClass = null;

            return null;
        }

        public DataType Visit(PublicModifier node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(PrivateModifier node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(FieldDecl node, CompileEnviroment env)
        {
            node.Decl.Accept(this, env);
            return null;
        }

        public DataType Visit(MethodDecl node, CompileEnviroment env)
        {
            env.CurrentMethod = node;
            env.SymbolTable.EnterScope();
            foreach(var par in node.Params)
            {
                env.SymbolTable.AddSymbol(new Symbol(par.Name.Name, par.DataType), par.Line, par.Column);
            }
            foreach(var decl in node.Decls)
            {
                decl.Accept(this, env);
            }
            //foreach(var stmt in node.Statements)
            //{
            //    stmt.Accept(this, env);
            //}
            env.SymbolTable.ExitScope();
            env.CurrentMethod = null;
            return null;
        }

        public DataType Visit(VarDecl node, CompileEnviroment env)
        {
            return null;
        }

        public DataType Visit(ConstDecl node, CompileEnviroment env)
        {
            if (!CheckerHelper.IsConstantExpression(node.Value, env))
            {
                throw new IllegalConstantExpressionException(node.Name.Name, node.Value.ToString(), node.Line, node.Column);
            }
            return null;
        }

        public DataType Visit(Assign node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(Return node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(CallMethodStmt node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(BinaryOp node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(UnaryOp node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(CallExpression node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(NewExpression node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(FieldAccess node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(IntLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(FloatLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(StringLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(BooleanLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(ThisLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(ID node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(IntType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(FloatType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(BooleanType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(StringType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(VoidType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(ClassType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
