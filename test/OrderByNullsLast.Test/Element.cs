namespace OrderByNullsLast.Test
{
    public class Element
    {
        public Element(double? val)
        {
            Value = val;
        }

        public double? Value { get; }
    }
}
