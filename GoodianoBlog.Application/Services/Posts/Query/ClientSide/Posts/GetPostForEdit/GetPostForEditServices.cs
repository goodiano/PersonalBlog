using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostForEdit
{
    public class GetPostForEditServices : IGetPostForEditServices
    {
        private readonly IDataBaseContext _context;
        public GetPostForEditServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetPostForEditDto> Execute(int Id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                .Where(p => p.Id == Id)
                .FirstOrDefault();


            return new ResultDto<GetPostForEditDto>
            {
                Data = new GetPostForEditDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Author = post.Author,
                    FirstSlideSrc = post.FirstSlideSrc,
                    PostCategory = post.PostCategories,
                    Content = post.Content,
                    Time = post.Time,
                },
                IsSuccess = true,
            };
        }
    }
}
