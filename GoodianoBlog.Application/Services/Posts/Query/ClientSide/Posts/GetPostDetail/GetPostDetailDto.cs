using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostDetail
{
    public class GetPostDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string FirstSlideSrc { get; set; }
        public string Content { get; set; }
        public int CountView { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
        public PostCategory PostCategories { get; set; }
        public List<GetAllCommentDto> GetComments { get; set; }

    }

    public class GetAllCommentDto
    {
        public int Id { get; set; }
        public string UserName{ get; set; }
        public string Context { get; set; }
        public bool IsConfirm { get; set; }
        public List<GetAllCommentReplayDto>? GetCommentReplays { get; set; }

    }

    public class GetAllCommentReplayDto
    {
        public string UserName { get; set; }
        public string Context { get; set; }
        public bool IsConfirm { get; set; }
        public int CommentId { get; set; }
    }
}
