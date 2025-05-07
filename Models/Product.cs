namespace HelloWorld.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int? Price { get; set; }
    }
}
