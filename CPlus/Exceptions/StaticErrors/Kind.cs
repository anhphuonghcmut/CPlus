namespace CPlus.Exceptions
{
    public class Kind
    {
    }

    public class Class : Kind
    {
        public override string ToString()
        {
            return "Class";
        }
    }

    public class Method : Kind
    {
        public override string ToString()
        {
            return "Method";
        }
    }

    public class Attribute : Kind
    {
        public override string ToString()
        {
            return "Attribute";
        }
    }

    public class Variable : Kind
    {
        public override string ToString()
        {
            return "Variable";
        }
    }

    public class Constant : Kind
    {
        public override string ToString()
        {
            return "Constant";
        }
    }

    public class Identifier : Kind
    {
        public override string ToString()
        {
            return "Identifier";
        }
    }

    public class Parameter : Kind
    {
        public override string ToString()
        {
            return "Parameter";
        }
    }
}
