using Antlr4.Runtime.Misc;
using CPlus.Helpers;
using CPlusAST;

namespace CPlus

{
    public class CPlusASTVisitor : CPlusBaseVisitor<AST>
    {
        public override AST VisitProgram([NotNull] CPlusParser.ProgramContext context)
        {
            var lineAndCol = ASTGenerationHelper.GetLineAndCol(context);
            return new CPlusAST.Program(context.class_decl().Select(node => (ClassDecl)Visit(node))).SetPosition(lineAndCol);
        }

        public override AST VisitClass_decl([NotNull] CPlusParser.Class_declContext context)
        {
            return new ClassDecl(
                new ID(context.ID().GetText()),
                context.members().Select(node => (Member)Visit(node))
            );
        }

        public override AST VisitMembers([NotNull] CPlusParser.MembersContext context)
        {
            if (context.field_decl() != null) {
                return (FieldDecl)Visit(context.field_decl());
            }
            return (MethodDecl)Visit(context.method_decl());
        }

        public override AST VisitField_decl([NotNull] CPlusParser.Field_declContext context)
        {
            return new FieldDecl(
                    context.PUBLIC() != null ? new PublicModifier() : new PrivateModifier(),
                    (StoreDecl)Visit(context.var_decl()));
        }

        public override AST VisitVar_decl([NotNull] CPlusParser.Var_declContext context)
        {
            var name = new ID(context.attribute().ID().GetText());
            Expression? expr = context.attribute().expr() != null ?
                                    (Expression)Visit(context.attribute().expr()) : null;
            if (context.IMMUTABLE() != null)
            {
                return new ConstDecl(
                    (DataType)Visit(context.data_type()),
                    name,
                    expr);
            }
            return new VarDecl(
                    (DataType)Visit(context.data_type()),
                    name,
                    expr);
        }

        public override AST VisitMethod_decl([NotNull] CPlusParser.Method_declContext context)
        {
            Modifier modifier = context.PUBLIC() != null ? new PublicModifier() : new PrivateModifier();

            var name = new ID(context.ID().GetText());

            DataType returnType = context.VOID() != null ? new VoidType() : (DataType)Visit(context.data_type());

            var paramList = new List<VarDecl>();
            var paramNode = context.parameter();
            if (paramNode.ChildCount > 0)
            {
                paramList.Add(new VarDecl((DataType)Visit(paramNode.data_type()), new ID(paramNode.ID().GetText()), null));
                var paramListNode = paramNode.parameter_list();
                if (paramListNode?.Length > 0)
                {
                    foreach(var p in paramListNode)
                    {
                        paramList.Add(new VarDecl((DataType)Visit(p.data_type()), new ID(p.ID().GetText()), null));
                    }
                }
            }

            var varDeclNode = context.method_body().var_decl();
            var statementNode = context.method_body().statement();
            var varDeclList = new List<StoreDecl>();
            var stmtList = new List<Statement>();
            if (varDeclNode != null) { 
                foreach(var v in varDeclNode)
                {
                    varDeclList.Add((StoreDecl)Visit(v));
                }
            }
            if (statementNode != null)
            {
                foreach (var s in statementNode)
                {
                    stmtList.Add((Statement)Visit(s));
                }
            }

            return new MethodDecl(modifier, returnType, name, paramList, varDeclList, stmtList);
        }
    }
}
