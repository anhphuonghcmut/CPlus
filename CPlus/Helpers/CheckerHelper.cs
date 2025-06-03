using CPlus.SematicChecker;
using CPlusAST;
using System;

namespace CPlus.Helpers
{
    public class CheckerHelper
    {
        public static bool IsConstantExpression(AST node, CompileEnviroment env)
        {
            switch (node)
            {
                case ThisLiteral: return false;
                case Literal: return true;

                case BinaryOp binaryOp:
                    return IsConstantExpression(binaryOp.Left, env) && IsConstantExpression(binaryOp.Right, env);
                case UnaryOp unaryOp:
                    return IsConstantExpression(unaryOp.Body, env);
                case ID id:
                    // Find in class first
                    if (env.CurrentClass.Members.TryGetValue(id.Name, out var fieldSymbol))
                    {
                        return fieldSymbol.IsImmutable;
                    }
                    else
                    {
                        // Find in scope
                        var symbol = env.SymbolTable.Lookup(id.Name, id.Line, id.Column);
                        return symbol.IsImmutable;
                    }
                case FieldAccess fieldAccess:
                    if (fieldAccess.Obj is not ID)
                    {
                        return false;
                    }
                    var classId = (ID)fieldAccess.Obj;
                    var classSymbol = env.SymbolTable.LookupClass(classId.Name, classId.Line, classId.Column);
                    fieldSymbol = classSymbol.Members[fieldAccess.FieldName.Name];
                    return fieldSymbol.IsImmutable;

                default: return false;
            }
        }

        public static bool CanAssign(DataType fromType, DataType toType, CompileEnviroment env)
        {
            if (fromType is StringType && toType is StringType)
            {
                return true;
            }
            else if (fromType is BooleanType && toType is BooleanType)
            {
                return true;
            }
            else if (fromType is ClassType a && toType is ClassType b)
            {
                return a.ClassName.Name == b.ClassName.Name;
            }
            else if (fromType is IntType && toType is IntType)
            {
                return true;
            }
            else if (fromType is FloatType && toType is FloatType)
            {
                return true;
            }
            else if (fromType is FloatType && toType is IntType)
            {
                return true;
            }
            return false;
        }
    }
}
