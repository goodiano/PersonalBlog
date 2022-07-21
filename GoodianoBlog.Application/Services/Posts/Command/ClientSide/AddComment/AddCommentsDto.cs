namespace GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment
{
    public class AddCommentsDto
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsConfirm { get; set; }
        public int PostId { get; set; }
    }
}
