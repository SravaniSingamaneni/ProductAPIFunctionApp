
namespace ProductAPIFunctionApp.Models
{
    public class ProductMessage
    {
        public string Action {  get; set; }
        public Product Product { get; set; }
        public string ProductId {  get; set; }
    }
}
