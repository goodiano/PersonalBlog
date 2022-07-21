using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostDetail
{
    public class GetPostDetailServices : IGetPostDetailServices
    {
        private readonly IDataBaseContext _context;
        public GetPostDetailServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<GetPostDetailDto> Execute(int Id)
        {
            var post = _context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategories)
                .Include(p=> p.Comments)
                .ThenInclude(p=> p.CommentReplays)
                .Where(p => p.Id == Id)
                .FirstOrDefault();


            post.CountView++;
            _context.SaveChanges();


            return new ResultDto<GetPostDetailDto>
            {
                Data = new GetPostDetailDto
                {
                    Id = post.Id,
                    Author = post.Author,
                    FirstSlideSrc = post.FirstSlideSrc,
                    Time = post.Time,
                    PostCategories = post.PostCategories,
                    Content = post.Content,
                    Title = post.Title,
                    CountView = post.CountView,
                    Date = post.InsertTime,
                    GetComments = post.Comments.Select(p=> new GetAllCommentDto
                    {
                        Id = p.Id,
                        Context = p.Context,
                        UserName = p.UserName,
                        IsConfirm = p.IsConfirm,
                        GetCommentReplays = p.CommentReplays.Select(comment => new GetAllCommentReplayDto
                        {
                            Context = comment.Context,
                            IsConfirm = comment.IsConfirm,
                            UserName  = comment.UserName,
                            CommentId = comment.CommentsId
                        }).ToList(),
                    }).ToList(), 
                },
                IsSuccess = true
            };
        }
    }
}
