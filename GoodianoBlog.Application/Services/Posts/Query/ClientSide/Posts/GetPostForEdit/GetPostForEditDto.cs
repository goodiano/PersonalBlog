using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostForEdit
{
    public class GetPostForEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string FirstSlideSrc { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
        public virtual PostCategory PostCategory { get; set; }
       
    }
}
