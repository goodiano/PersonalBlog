using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts
{
    public class PostsInClientSideDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public int CountView { get; set; }        
        public string Category { get; set; }
    }
}
