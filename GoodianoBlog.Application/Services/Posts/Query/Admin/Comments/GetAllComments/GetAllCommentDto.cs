namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Comments.GetAllComments
{
    public class GetAllCommentDto
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public string Email { get; set; }
        public bool IsConfirm { get; set; }
        public string PostTitle { get; set; }
        public string UserName { get; set; }
    }
}
