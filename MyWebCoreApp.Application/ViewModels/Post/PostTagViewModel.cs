namespace MyWebCoreApp.Application.ViewModels.Post
{
    public class PostTagViewModel
    {
        public int Id { set; get; }

        public int PostId { get; set; }

        public string TagId { get; set; }

        public PostViewModel Post { get; set; }

        public TagViewModel Tag { get; set; }
    }
}