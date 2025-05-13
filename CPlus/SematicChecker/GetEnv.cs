using CPlus.Exceptions;
using CPlus.Exceptions.StaticErrors;
using CPlusAST;

namespace CPlus.SematicChecker
{
    public class GetEnv : IASTVisitor<CompileEnviroment>
    {
        public CompileEnviroment Visit(CPlusAST.Program node, CompileEnviroment env)
        {
            // Collect data of classes
            foreach (var classDecl in node.ClassDecls)
            {
                var classSymbol = new ClassSymbol(classDecl.Name.Name);
                env.SymbolTable.AddClass(classDecl.Name.Name, classSymbol);
            }

            // Handle class members
            foreach (var classDecl in node.ClassDecls)
            {
                classDecl.Accept(this, env);
            }

            return env;
        }

        public CompileEnviroment Visit(ClassDecl node, CompileEnviroment env)
        {
            env.CurrentClass = env.SymbolTable.LookupClass(node.Name.Name, node.Line, node.Column);
            foreach (var mem in node.Members)
            {
                mem.Accept(this, env);
            }
            env.CurrentClass = null;

            return null;
        }

        public CompileEnviroment Visit(PublicModifier node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(PrivateModifier node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(FieldDecl node, CompileEnviroment env)
        {
            if (env.CurrentClass.Members.ContainsKey(node.Decl.Name.Name))
            {
                throw new RedeclaredException(new Exceptions.Attribute(), node.Decl.Name.Name, node.Line, node.Column);
            }
            var fieldSymbol = new Symbol(
                node.Decl.Name.Name,
                node.Decl.DataType,
                node.Decl is ConstDecl,
                node.FieldModifier is PublicModifier);
            env.CurrentClass.Members.Add(node.Decl.Name.Name, fieldSymbol);
            return null;
        }

        public CompileEnviroment Visit(MethodDecl node, CompileEnviroment env)
        {
            if (env.CurrentClass.Members.ContainsKey(node.Name.Name))
            {
                throw new RedeclaredException(new Method(), node.Name.Name, node.Line, node.Column);
            }
            var fieldSymbol = new MethodSymbol(
                node.Name.Name,
                node.ReturnType,
                isPublic: node.MethodModifier is PublicModifier,
                parameters: node.Params);
            env.CurrentClass.Members.Add(node.Name.Name, fieldSymbol);

            return null;
        }

        public CompileEnviroment Visit(VarDecl node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(ConstDecl node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(Assign node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(Return node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(CallMethodStmt node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(BinaryOp node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(UnaryOp node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(CallExpression node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(NewExpression node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(FieldAccess node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(IntLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(FloatLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(StringLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(BooleanLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(ThisLiteral node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(ID node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(IntType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(FloatType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(BooleanType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(StringType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(VoidType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }

        public CompileEnviroment Visit(ClassType node, CompileEnviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
