
namespace GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment
{
    public class RequestAddComments
    {
        public string Context { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
    }
}
