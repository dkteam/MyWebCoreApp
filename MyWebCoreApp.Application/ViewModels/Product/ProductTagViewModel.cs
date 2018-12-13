namespace MyWebCoreApp.Application.ViewModels.Product
{
    public class ProductTagViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string TagId { set; get; }

        public ProductViewModel Product { get; set; }

        public TagViewModel Tag { get; set; }
    }
}