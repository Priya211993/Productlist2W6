// See https://aka.ms/new-console-template for more information
class Product
{
    public string Category { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Category: {Category}, Name: {Name}, Price: {Price:C}";
    }
}

class ProductManager
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayList()
    {
        if (products.Any())
        {
            Console.WriteLine("\nList of Products:");

            // Sort the products by price using LINQ
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            foreach (Product product in sortedProducts)
            {
                Console.WriteLine(product);
            }

            // Calculate and display the total price using LINQ
            double totalPrice = sortedProducts.Sum(p => p.Price);
            Console.WriteLine($"\nTotal Price: {totalPrice:C}");
        }
        else
        {
            Console.WriteLine("\nNo products added yet.");
        }
    }
}

class Program
{
    static void Main()
    {
        ProductManager productManager = new ProductManager();

        Console.WriteLine("To enter a new product - follow the steps |  To quit - enter: Q ");

        while (true)
        {
            try
            {
                Console.Write("Enter a product category : ");
                string category = Console.ReadLine();

                if (category.ToLower() == "Q")
                    break;

                Console.Write("Enter a product name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter a product price: ");
                double productPrice;
                while (!double.TryParse(Console.ReadLine(), out productPrice) || productPrice < 0)
                {
                    Console.WriteLine("Incorrect Price!");
                }

                Product newProduct = new Product { Category = category, Name = productName, Price = productPrice };
                productManager.AddProduct(newProduct);

                // Display the updated list using ProductManager
                productManager.DisplayList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
