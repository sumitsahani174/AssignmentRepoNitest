namespace AssignmentProject.Models.DTOs.Request
{
    public class ProductInventoryRequest
    {
        public string? InventoryType { get; set; }
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Amount { get; set; }
        public string? Brand { get; set; }
        public string? Quantity { get; set; }
        public string? Status { get; set; }
        public List<ProductImage>? Images { get; set; } = new List<ProductImage>();
    }
    public class ProductImage
    {
        public string? ImageID { get; set; }
        public string? ImageBase64 { get; set; }
        public string? Status { get; set; }
    }
}
