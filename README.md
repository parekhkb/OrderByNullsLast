# OrderByNullsLast
Simple C# library to specify whether to place nulls first or last when ordering an enumerable by a key selector with nullable types.

[![Build status](https://ci.appveyor.com/api/projects/status/k65uuhcf2oq8mbf6/branch/master?svg=true)](https://ci.appveyor.com/project/parekhkb/orderbynullslast/branch/master)

[Nuget Package Link](https://www.nuget.org/packages/OrderByNullsLast/)

# Example

The default behavior of System.Linq.OrderBy would always place null values first. Using the OrderByNullsLast package, it allows us to specify either nulls first, or nulls last, regardless of sort order, without having to create a custom IComparer.

```c#
using System.Linq;

public class Element
{
    public Element(double? val)
    {
        Value = val;
    }

    public double? Value { get; }
}

var list = new List<Element>
{
    new Element(3),
    new Element(null),
    new Element(1),
    new Element(2),
    new Element(null)
};

list.OrderBy(x=>x.Value, NullOrder.First) // null, null, 1, 2, 3
list.OrderBy(x=>x.Value, NullOrder.Last) // 1, 2, 3, null, null
list.OrderByDescending(x=>x.Value, NullOrder.First) // null, null, 3, 2, 1
list.OrderByDescending(x=>x.Value, NullOrder.Last) // 3, 2, 1, null, null
```