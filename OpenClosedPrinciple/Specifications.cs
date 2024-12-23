namespace OpenClosedPrinciple;

/// <summary>
/// We have levereged Specification pattern here to ensure Open Closed Principle is not violated here.
/// </summary>
/// <typeparam name="T"></typeparam>

internal interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}

internal class ColorSpecification : ISpecification<Product>
{
    private readonly Color _color;
    public ColorSpecification(Color color)
    {
        _color = color;
    }
    public bool IsSatisfiedBy(Product item)
    {
        return item.Color == _color;
    }
}

internal class SizeSpecification : ISpecification<Product>
{
    private readonly Size _size;
    public SizeSpecification(Size size)
    {
        _size = size;
    }
    public bool IsSatisfiedBy(Product item)
    {
        return item.Size == _size;
    }
}

internal class AndSpecification : ISpecification<Product>
{
    private readonly ISpecification<Product> _left;

    private readonly ISpecification<Product> _right;

    public AndSpecification(ISpecification<Product> left, ISpecification<Product> right)
    {
        _left = left;
        _right = right;
    }
    public bool IsSatisfiedBy(Product item)
    {
        return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
    }
}

internal interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}

internal class ProductFilterV2 : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> spec)
    {
        foreach (var p in products) 
        {
            if (spec.IsSatisfiedBy(p))
            {
                yield return p;
            }
        }
    }
}
