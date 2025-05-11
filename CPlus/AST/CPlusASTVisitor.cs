using Antlr4.Runtime.Misc;
using CPlus.Helpers;
using CPlusAST;
using System.Globalization;

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
                return Visit(context.field_decl());
            }
            return Visit(context.method_decl());
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
            if (paramNode != null)
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

        // Visit Expression
        public override AST VisitExpr([NotNull] CPlusParser.ExprContext context)
        {
            if (context.ChildCount == 1)
            {
                return (Expression)Visit(context.expr3()[0]);
            }
            var op = context.EQUAL() ==  null ? context.NOT_EQUAL().GetText() : context.EQUAL().GetText();
            return new BinaryOp(op, (Expression)Visit(context.expr3()[0]), (Expression)Visit(context.expr3()[1]));
        }
        public override AST VisitExpr3([NotNull] CPlusParser.Expr3Context context)
        {
            if (context.ChildCount == 1)
            {
                return Visit(context.expr4());
            }
            var op = context.ADD() == null ? context.SUB().GetText() : context.ADD().GetText();
            return new BinaryOp(op, (Expression)Visit(context.expr3()), (Expression)Visit(context.expr4()));
        }
        public override AST VisitExpr4([NotNull] CPlusParser.Expr4Context context)
        {
            if (context.ChildCount == 1)
            {
                return Visit(context.expr6());
            }
            var op = context.MUL() == null ? context.DIV().GetText() : context.MUL().GetText();
            return new BinaryOp(op, (Expression)Visit(context.expr4()), (Expression)Visit(context.expr6()));
        }
        public override AST VisitExpr6([NotNull] CPlusParser.Expr6Context context)
        {
            if (context.ChildCount == 1)
            {
                return Visit(context.expr7());
            }
            return new UnaryOp(context.NOT().GetText(), (Expression)Visit(context.expr6()));
        }
        public override AST VisitExpr7([NotNull] CPlusParser.Expr7Context context)
        {
            if (context.ChildCount == 1)
            {
                return (Expression)Visit(context.expr9());
            }
            var op = context.ADD() == null ? context.SUB().GetText() : context.ADD().GetText();
            return new UnaryOp(op, (Expression)Visit(context.expr7()));
        }
        public override AST VisitExpr9([NotNull] CPlusParser.Expr9Context context)
        {
            if (context.ChildCount == 1)
            {
                return (Expression)Visit(context.expr10());
            }
            if (context.ChildCount == 3)
            {
                return new FieldAccess((Expression)Visit(context.expr9()), new ID(context.ID().GetText()));
            }
            return new CallExpression((Expression)Visit(context.expr9()), new ID(context.ID().GetText()), VisitList_of_expr(context.list_of_expr()));
        }
        public override AST VisitExpr10([NotNull] CPlusParser.Expr10Context context)
        {
            if (context.ChildCount == 1)
            {
                return (Expression)Visit(context.expr11());
            }
            return new NewExpression(new ID(context.ID().GetText()));
        }
        public override AST VisitExpr11([NotNull] CPlusParser.Expr11Context context)
        {
            if (context.ID() != null)
            {
                return new ID(context.ID().GetText());
            }
            else if (context.literal() != null)
            {
                return Visit(context.literal());
            }
            else if (context.THIS() != null)
            {
                return new ThisLiteral();
            }
            return Visit(context.expr());
        }
        public override AST VisitLiteral([NotNull] CPlusParser.LiteralContext context)
        {
            if (context.INTLIT() != null)
            {
                return new IntLiteral(int.Parse(context.INTLIT().GetText()));
            }
            else if (context.FLOATLIT() != null)
            {
                return new FloatLiteral(float.Parse(context.FLOATLIT().GetText(), CultureInfo.InvariantCulture));
            }
            else if (context.BOOLLIT() != null)
            {
                return new BooleanLiteral(bool.Parse(context.BOOLLIT().GetText()));
            }
            return new StringLiteral(context.STRINGLIT().GetText());
        }

        // Statements
        public override AST VisitStatement([NotNull] CPlusParser.StatementContext context)
        {
            if (context.assignment_statement() != null)
            {
                return Visit(context.assignment_statement());
            }
            else if (context.return_statement() != null)
            {
                return Visit(context.return_statement());
            }
            return Visit(context.method_invocation_statement());
        }
        public override AST VisitAssignment_statement([NotNull] CPlusParser.Assignment_statementContext context)
        {
            var lhs = context.ID() == null ? (LHS)Visit(context.expr9()) : (LHS)Visit(context.ID());

            return new Assign(lhs, (Expression)Visit(context.expr()));
        }
        public override AST VisitReturn_statement([NotNull] CPlusParser.Return_statementContext context)
        {
            if (context.expr() != null)
            {
                return new Return((Expression)Visit(context.expr()));
            }
            return new Return(null);
        }
        public override AST VisitMethod_invocation_statement([NotNull] CPlusParser.Method_invocation_statementContext context)
        {
            return Visit(context.member_access());
        }
        public override AST VisitMember_access([NotNull] CPlusParser.Member_accessContext context)
        {
            var obj = context.expr() == null ? new ID(context.ID()[0].GetText()) : Visit(context.expr());

            return new CallMethodStmt((Expression)obj, new ID(context.ID()[^1].GetText()), VisitList_of_expr(context.list_of_expr()));
        }

        // Visit data types
        public override AST VisitData_type([NotNull] CPlusParser.Data_typeContext context)
        {
            if (context.type_not_void() == null)
            {
                return Visit(context.class_type());
            }
            return Visit(context.type_not_void());
        }
        public override AST VisitType_not_void([NotNull] CPlusParser.Type_not_voidContext context)
        {
            if (context.INT() != null)
            {
                return new IntType();
            }
            else if (context.FLOAT() != null)
            {
                return new FloatType();
            }
            else if (context.STRING() != null)
            {
                return new StringType();
            }
            return new BooleanType();
        }
        public override AST VisitClass_type([NotNull] CPlusParser.Class_typeContext context)
        {
            return new ClassType(new ID(context.ID().GetText()));
        }

        // Custom handle list_of_expr
        public new IEnumerable<Expression> VisitList_of_expr([NotNull] CPlusParser.List_of_exprContext? context)
        {
            var exprList = new List<Expression>();
            if (context == null)
            {
                return exprList;
            }
            foreach(var exprNode in context.expr())
            {
                exprList.Add((Expression)Visit(exprNode));
            }
            return exprList;
        }
    }
}
