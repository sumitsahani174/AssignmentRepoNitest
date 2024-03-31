using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;

namespace AssignmentProject.DataAccessLayer.Interface
{
    public interface IProductInventory
    {
        public GenericResponse AddProduct(ProductInventoryRequest productInventory);
        public GenericResponse GetProducts(ProductInventoryRequest productInventory);
    }
}
