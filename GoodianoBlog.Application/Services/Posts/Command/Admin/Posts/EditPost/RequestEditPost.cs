using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.EditPost
{
    public class RequestEditPost
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int Author { get; set; }
        public string Time { get; set; }
        public int PostCategory { get; set; }
        public string FirstSlideSrc { get; set; }       
        public string Content { get; set; }       
        
    }
}
