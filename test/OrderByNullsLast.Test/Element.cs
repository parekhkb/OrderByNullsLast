namespace OrderByNullsLast.Test
{
    public class Element
    {
        public Element(double? structVal)
        {
            StructValue = structVal;
        }
        public Element(string stringVal)
        {
            ClassValue = stringVal;
        }

        public double? StructValue { get; }

        public string ClassValue { get; }
    }
}
