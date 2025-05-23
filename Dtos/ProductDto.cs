namespace HelloWorld.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal? Price { get; set; }
        public CategoryDto Category { get; set; } = default!;
    }
}
