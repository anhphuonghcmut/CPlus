using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace CPlus

{
    public class CPlusASTVisitor : CPlusBaseVisitor<CPlusAST>
    {
        public override CPlusAST VisitProgram([NotNull] CPlusParser.ProgramContext context)
        {
            var programDecl = new ProgramDecl();
            var classDecls = new List<ClassDecl>();
            foreach(var classDeclNode in context.class_decl())
            {
                var classDecl = (ClassDecl)Visit(classDeclNode);
                classDecls.Add(classDecl);
            }
            programDecl.ClassDecls = classDecls;
            return programDecl;
        }

        public override CPlusAST VisitClass_decl([NotNull] CPlusParser.Class_declContext context)
        {
            var classDecl = new ClassDecl();
            var methodDecls = new List<MethodDecl>();
            foreach (var methodDeclNode in context.method_decl())
            {
                var methodDecl = (MethodDecl)Visit(methodDeclNode) ;
                methodDecls.Add(methodDecl);
            }
            classDecl.MethodDecls = methodDecls;
            classDecl.ClassId = new ID(context.ID().GetText());
            return classDecl;
        }

        public override CPlusAST VisitMethod_decl([NotNull] CPlusParser.Method_declContext context)
        {
            var methodDecl = new MethodDecl();
            if (context.PUBLIC() != null) {
                methodDecl.MethodModifier = Modifier.PUBLIC;
            }
            else if (context.PRIVATE() != null)
            {
                methodDecl.MethodModifier = Modifier.PRIVATE;
            }
            else
            {
                methodDecl.MethodModifier = Modifier.PUBLIC;
            }

            methodDecl.MethodType = (BaseType)Visit(context.type());
            methodDecl.MethodId = new ID(context.ID().GetText());

            return methodDecl;
        }

        public override CPlusAST VisitType([NotNull] CPlusParser.TypeContext context)
        {
            return Visit(context.GetChild(0));
        }

        public override CPlusAST VisitNumeric_type([NotNull] CPlusParser.Numeric_typeContext context)
        {
            var typeName = context.GetChild(0).GetText();
            if (typeName == "int")
            {
                return new IntType();
            }
            else
            {
                return new FloatType();
            }
        }

        public override CPlusAST VisitString_type([NotNull] CPlusParser.String_typeContext context)
        {
            return new StringType();
        }

        public override CPlusAST VisitBool_type([NotNull] CPlusParser.Bool_typeContext context)
        {
            return new BooleanType();
        }

        public override CPlusAST VisitVoid_type([NotNull] CPlusParser.Void_typeContext context)
        {
            return new VoidType();
        }
    }
}
