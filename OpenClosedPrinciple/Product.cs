namespace OpenClosedPrinciple;
internal enum Color
{
    Green,
    Red,
    Yellow,
    Blue
}
internal enum Size
{
    Small,
    Medium,
    Large
}
internal record Product(string Name, Color Color, Size Size)
{
}

/// <summary>
/// This violates Open-Closed Principle because as and when a new filter needs to be added, this class has to be updated.
/// </summary>
internal class ProductFilterV1
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach(var p in products)
        {
            if(p.Size == size)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var p in products)
        {
            if (p.Color == color)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products,Size size, Color color)
    {
        foreach (var p in products)
        {
            if (p.Size == size && p.Color == color)
            {
                yield return p;
            }
        }
    }
}