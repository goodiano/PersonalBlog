namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllPosts
{
    public class ResultGetAllPostsDto
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string FirstSlideSrc { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string PostCategory { get; set; }
    }
}
