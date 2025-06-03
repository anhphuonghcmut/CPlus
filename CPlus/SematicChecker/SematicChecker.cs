using Antlr4.Runtime.Misc;
using CPlus.Exceptions;
using CPlus.Exceptions.StaticErrors;
using CPlus.Helpers;
using CPlusAST;
using System;

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
            if (node.ReturnType is ClassType classType)
            {
                env.SymbolTable.LookupClass(classType.ClassName.Name, node.Line, node.Column);
            }
            env.CurrentMethod = node;
            env.SymbolTable.EnterScope();
            foreach(var par in node.Params)
            {
                env.SymbolTable.AddParamSymbol(new Symbol(par.Name.Name, par.DataType), par.Line, par.Column);
            }
            foreach(var decl in node.Decls)
            {
                decl.Accept(this, env);
            }

            // Expect for void, method must return
            if (node.Statements.Where(s => s is Return).Count() < 1)
            {
                throw new TypeMismatchInStatementException("Method must return", node.ReturnType?.ToString(), "None", node.Line, node.Column);
            }
            foreach (var stmt in node.Statements)
            {
                stmt.Accept(this, env);
            }
            env.SymbolTable.ExitScope();
            env.CurrentMethod = null;
            return null;
        }

        public DataType Visit(VarDecl node, CompileEnviroment env)
        {
            if (node.DataType is ClassType classType)
            {
                env.SymbolTable.LookupClass(classType.ClassName.Name, node.Line, node.Column);
            }
            
            // For FieldDecl, only checking type, not save symbol to scope stack
            if (env.CurrentMethod != null)
            {
                env.SymbolTable.AddSymbol(new Symbol(node.Name.Name, node.DataType), node.Line, node.Column);
            }

            if (node.Value != null)
            {
                //var valueType = node.Value.Accept(this, env);

            }
            return null;
        }

        public DataType Visit(ConstDecl node, CompileEnviroment env)
        {
            if (node.DataType is ClassType classType)
            {
                env.SymbolTable.LookupClass(classType.ClassName.Name, node.Line, node.Column);
            }

            // For FieldDecl, only checking type, not save symbol to scope stack
            if (env.CurrentMethod != null) { 
                env.SymbolTable.AddSymbol(new Symbol(node.Name.Name, node.DataType, isImmutable: true), node.Line, node.Column);
            }
            if (!CheckerHelper.IsConstantExpression(node.Value, env))
            {
                throw new IllegalConstantExpressionException(node.Name.Name, node.Value?.ToString(), node.Line, node.Column);
            }
            return null;
        }

        public DataType Visit(Assign node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public DataType Visit(Return node, CompileEnviroment env)
        {
            var returnType = env.CurrentMethod.ReturnType;
            if (env.CurrentMethod.ReturnType is VoidType && node.Expression != null)
            {
                throw new TypeMismatchInStatementException("Return", "Void", "Not-Void", node.Line, node.Column);
            }
            else if (env.CurrentMethod.ReturnType is VoidType && node.Expression == null)
            {
                return null;
            }
            else if (node.Expression == null)
            {
                throw new TypeMismatchInStatementException("Return", returnType.ToString(), "Void", node.Line, node.Column);
            }
            var expectedType = node.Expression.Accept(this, env);
            if(!CheckerHelper.CanAssign(returnType, expectedType, env))
            {
                throw new TypeMismatchInStatementException("Return", expectedType.ToString(), returnType.ToString(), node.Line, node.Column);
            }
            return null;
        }

        public DataType Visit(CallMethodStmt node, CompileEnviroment env)
        {
            DataType classExpr = null;
            if (node.Obj is ID id)
            {
                var symbol = env.SymbolTable.Lookup(id.Name, id.Line, id.Column);
                classExpr = symbol.Type;
            }
            else
            {
                classExpr = node.Obj.Accept(this, env);
            }

            if (classExpr is not ClassType)
            {
                throw new TypeMismatchInStatementException("Method call", "Class type", classExpr.ToString(), node.Line, node.Column);
            }

            var classSymbol = env.SymbolTable.LookupClass(((ClassType)classExpr).ClassName.Name, node.Line, node.Column);
            var methodSymbol = classSymbol.Members.FirstOrDefault(m => m.Key == node.Method.Name && m.Value is MethodSymbol).Value;

            if (methodSymbol == null)
            {
                throw new UndeclaredException(new Method(), node.Method.Name, node.Line, node.Column);
            }
            else if (methodSymbol.IsPublic == false)
            {
                throw new IllegalMemberAccessException(new Method(), node.Method.Name, ((ClassType)classExpr).ClassName.Name, node.Line, node.Column);
            }
            else if (methodSymbol.Type is not VoidType)
            {
                throw new TypeMismatchInStatementException("Method call", "Class type", classExpr.ToString(), node.Line, node.Column);
            }

            return null;
        }

        public DataType Visit(BinaryOp node, CompileEnviroment env)
        {
            var left = node.Left.Accept(this, env);
            var right = node.Right.Accept(this, env);

            if (!CheckerHelper.CanAssign(right, left, env))
            {
                throw new TypeMismatchInExpressionException(node.Op, left.ToString(), right.ToString(), node.Line, node.Column);
            }

            return left;
        }

        public DataType Visit(UnaryOp node, CompileEnviroment env)
        {
            return node.Body.Accept(this, env);
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
            return new IntType();
        }

        public DataType Visit(FloatLiteral node, CompileEnviroment env)
        {
            return new FloatType();
        }

        public DataType Visit(StringLiteral node, CompileEnviroment env)
        {
            return new StringType();
        }

        public DataType Visit(BooleanLiteral node, CompileEnviroment env)
        {
            return new BooleanType();
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
