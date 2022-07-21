using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllPosts
{
    public class GetAllPostsServices : IGetAllPostsServices
    {
        private readonly IDataBaseContext _context;
        public GetAllPostsServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<ResultGetAllPostsDto>> Execute()
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                .ToList()
                .Select(p => new ResultGetAllPostsDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author.Name,
                    FirstSlideSrc = p.FirstSlideSrc,
                    Time = p.Time,
                    PostCategory = p.PostCategories.Name,
                    Content = p.Content,
                }).ToList();

            return new ResultDto<List<ResultGetAllPostsDto>>
            {
                Data = post,
                IsSuccess = true,
                Message = ""
            };

        }
    }
}
