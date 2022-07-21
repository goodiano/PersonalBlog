namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost
{
    public class ImageGalleryDto
    {
        public int Id { get; set; }
        public string Src { get; set; }       
        public int PostId { get; set; }
        public int ImageGalleryId { get; set; }
    }
}
