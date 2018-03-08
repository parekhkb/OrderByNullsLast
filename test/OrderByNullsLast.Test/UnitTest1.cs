using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace OrderByNullsLast.Test
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void OrderByAscending_NullsFirst_CorrectlyOrderedListReturned()
        {
            var list = new List<Element>
            {
                new Element(3),
                new Element(null),
                new Element(1),
                new Element(2),
                new Element(null)
            };

            var expected = new double?[] { null, null, 1, 2, 3 };
            var actual = list.OrderBy(x => x.Value, NullOrder.NullsFirst).Select(x => x.Value);

            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void OrderByAscending_NullsLast_CorrectlyOrderedListReturned()
        {
            var list = new List<Element>
            {
                new Element(3),
                new Element(null),
                new Element(1),
                new Element(2),
                new Element(null)
            };

            var expected = new double?[] { 1, 2, 3, null, null };
            var actual = list.OrderBy(x => x.Value, NullOrder.NullsLast).Select(x => x.Value);

            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void OrderByDescending_NullsLast_CorrectlyOrderedListReturned()
        {
            var list = new List<Element>
            {
                new Element(3),
                new Element(null),
                new Element(1),
                new Element(2),
                new Element(null)
            };

            var expected = new double?[] { 3, 2, 1, null, null };
            var actual = list.OrderByDescending(x => x.Value, NullOrder.NullsLast).Select(x => x.Value);

            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }


        [Fact]
        public void OrderByDescending_NullsFirst_CorrectlyOrderedListReturned()
        {
            var list = new List<Element>
            {
                new Element(3),
                new Element(null),
                new Element(1),
                new Element(2),
                new Element(null)
            };

            var expected = new double?[] { null, null, 3, 2, 1 };
            var actual = list.OrderByDescending(x => x.Value, NullOrder.NullsFirst).Select(x => x.Value);

            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }
    }

    public class Element
    {
        public Element(double? val)
        {
            Value = val;
        }

        public double? Value { get; }
    }
}
