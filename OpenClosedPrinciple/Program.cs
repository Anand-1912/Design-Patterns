namespace OpenClosedPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product iPhone = new(Name: "IPhone", Size: Size.Medium, Color: Color.Green);
            Product cycle = new(Name: "AXN-DX", Size: Size.Large, Color: Color.Red);
            Product tablet = new(Name: "Samsung", Size: Size.Large, Color: Color.Green);

            List<Product> products = new() { iPhone, cycle, tablet };

            IFilter<Product> filter = new ProductFilterV2();

            var greenProducts = filter.Filter(items: products, spec: new ColorSpecification(Color.Green));

            Console.WriteLine("Green Products--");

            foreach(var p in greenProducts)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Large Products--");
            var largeProducts = filter.Filter(items: products, spec: new SizeSpecification(Size.Large));

            foreach (var p in largeProducts)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
