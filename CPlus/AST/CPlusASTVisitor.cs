using Antlr4.Runtime.Misc;
using CPlusAST;

namespace CPlus

{
    public class CPlusASTVisitor : CPlusBaseVisitor<AST>
    {
        public override AST VisitProgram([NotNull] CPlusParser.ProgramContext context)
        {
            return new CPlusAST.Program(context.class_decl()
                                                    .Select(node => (ClassDecl)Visit(node)));
        }

        public override AST VisitClass_decl([NotNull] CPlusParser.Class_declContext context)
        {
            return new ClassDecl(
                new ID(context.ID().GetText()),
                context.members().Select(node => (Member)Visit(node))
            );
        }
    }
}
