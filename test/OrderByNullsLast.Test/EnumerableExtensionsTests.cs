using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace OrderByNullsLast.Test
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void KeyIsNullableStruct_OrderByAscendingNullsFirst_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element(3),
                new Element(structVal: null),
                new Element(1),
                new Element(2),
                new Element(structVal: null)
            };

            var expected = new double?[] { null, null, 1, 2, 3 };

            // Act
            var actual = list.OrderBy(x => x.StructValue, NullOrder.NullsFirst).Select(x => x.StructValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsNullableStruct_OrderByAscendingNullsLast_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element(3),
                new Element(structVal: null),
                new Element(1),
                new Element(2),
                new Element(structVal: null)
            };

            var expected = new double?[] { 1, 2, 3, null, null };

            // Act
            var actual = list.OrderBy(x => x.StructValue, NullOrder.NullsLast).Select(x => x.StructValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsNullableStruct_OrderByDescendingNullsLast_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element(3),
                new Element(structVal: null),
                new Element(1),
                new Element(2),
                new Element(structVal: null)
            };

            var expected = new double?[] { 3, 2, 1, null, null };

            // Act
            var actual = list.OrderByDescending(x => x.StructValue, NullOrder.NullsLast).Select(x => x.StructValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }
        
        [Fact]
        public void KeyIsNullableStruct_OrderByDescendingNullsFirst_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element(3),
                new Element(structVal: null),
                new Element(1),
                new Element(2),
                new Element(structVal: null)
            };

            var expected = new double?[] { null, null, 3, 2, 1 };

            // Act
            var actual = list.OrderByDescending(x => x.StructValue, NullOrder.NullsFirst).Select(x => x.StructValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsClass_OrderByAscendingNullsFirst_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element("3"),
                new Element(stringVal: null),
                new Element("1"),
                new Element("2"),
                new Element(stringVal: null)
            };

            object[] expected = { null, null, "1", "2", "3" };

            // Act
            var actual = list.OrderBy(x => x.ClassValue, NullOrder.NullsFirst).Select(x => x.ClassValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsClass_OrderByAscendingNullsLast_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element("3"),
                new Element(stringVal: null),
                new Element("1"),
                new Element("2"),
                new Element(stringVal: null)
            };

            object[] expected = { "1", "2", "3", null, null };

            // Act
            var actual = list.OrderBy(x => x.ClassValue, NullOrder.NullsLast).Select(x => x.ClassValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsClass_OrderByDescendingNullsLast_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element("3"),
                new Element(stringVal: null),
                new Element("1"),
                new Element("2"),
                new Element(stringVal: null)
            };

            object[] expected = { "3", "2", "1", null, null };

            // Act
            var actual = list.OrderByDescending(x => x.ClassValue, NullOrder.NullsLast).Select(x => x.ClassValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }

        [Fact]
        public void KeyIsClass_OrderByDescendingNullsFirst_CorrectlyOrderedListReturned()
        {
            // Arrange
            var list = new List<Element>
            {
                new Element("3"),
                new Element(stringVal: null),
                new Element("1"),
                new Element("2"),
                new Element(stringVal: null)
            };

            object[] expected = { null, null, "3", "2", "1" };

            // Act
            var actual = list.OrderByDescending(x => x.ClassValue, NullOrder.NullsFirst).Select(x => x.ClassValue);

            // Assert
            actual.Should().HaveSameCount(expected).And.ContainInOrder(expected);
        }
    }
}