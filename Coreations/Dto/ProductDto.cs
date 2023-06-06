using Core.Entities;

namespace COREationsTask.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CustomerID { get; set; }
    }
}
