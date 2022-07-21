using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Comments.GetAllComments
{
    public class GetAllCommentsService : IGetAllCommentsServices
    {
        private readonly IDataBaseContext _context;
        public GetAllCommentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetAllCommentDto>> Execute()
        {
            var comment = _context.Comments
                .Include(p => p.Post)
                .OrderByDescending(p => p.Id)
                .Select(p => new GetAllCommentDto
                {
                    Id = p.Id,
                    Context = p.Context,
                    Email = p.Email,
                    IsConfirm = p.IsConfirm,
                    UserName = p.UserName,
                    PostTitle = p.Post.Title
                }).ToList();


            return new ResultDto<List<GetAllCommentDto>>
            {
                Data = comment,
                IsSuccess = true,
            };
        }
    }
}
