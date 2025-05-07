namespace HelloWorld.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int? Price { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = new Category();
    }
}
