using Microsoft.AspNetCore.Http;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost
{
    public class RequestAddPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public IFormFile MainSlideSrc { get; set; }
        public int AuthorId { get; set; }
        public int TagId { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public string? Url { get; set; }
        public List<IFormFile?> ImageGallery { get; set; }
        public List<IFormFile?> SinglePhoto { get; set; }

    }
}
