namespace CPlus.Exceptions
{
    /// <summary>
    /// Redeclared Variable/Constant/Attribute/Class/Method/Params
    /// </summary>
    public class RedeclaredException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString() {
            return $"Redeclared {Kind.ToString()}: {Name}";
        }
    }

    /// <summary>
    /// Undeclared Identifier/Constant/Attribute/Class/Method
    /// </summary>
    public class UndeclaredException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }

    /// <summary>
    /// A constant cannot be assigned again
    /// </summary>
    public class CannotAssignToConstantException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }

    /// <summary>
    /// Assignment statement: left hand side can be any type except void, right hand side is the same type or can coerce to LHS,
    ///                       float is super type of int.
    /// Call statement: only void type could be call alone. Passing parameters obey the rules for assignment statement.
    /// Return statement: return expression can be consider as RHS and LHS is the return type of the method.
    /// </summary>
    public class TypeMismatchInStatementException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }

    public class TypeMisMatchInExpressionException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }

    /// <summary>
    /// A constant must be assigned with a static value (literals)
    /// </summary>
    public class IlligalConstantExpressionException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }

    /// <summary>
    /// Only public attribute/method can be accessed
    /// </summary>
    public class IlligalMemberAccessException : Exception
    {
        public Kind Kind { get; set; }
        // Name of the identifier
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Undeclared {Kind.ToString()}: {Name}";
        }
    }
}
