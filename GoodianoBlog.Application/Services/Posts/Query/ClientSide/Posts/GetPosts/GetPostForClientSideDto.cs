using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts
{
    public class GetPostForClientSideDto
    {
        public Post LastPost { get; set; }
        public int TotalRow { get; set; }
        public List<PostsInClientSideDto> Posts { get; set; }
    }
}
