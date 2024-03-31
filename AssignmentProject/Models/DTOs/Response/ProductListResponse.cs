namespace AssignmentProject.Models.DTOs.Response
{
    public class ProductListResponse
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Quantity { get; set; }
        public string Brand { get; set; }
        public List<ImageList> imageLists { get; set; }
    }
    public class ImageList
    {
        public int ImageID { get; set; }
        public string ImageData { get; set; }
    }
}
