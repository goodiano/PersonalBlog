using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Comments.ChangeStatus
{
    public class CommentChangeStatusServices : ICommentChangeStatusServices
    {
        private readonly IDataBaseContext _context;
        public CommentChangeStatusServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var comment = _context.Comments.Find(Id);

            comment.IsConfirm = !comment.IsConfirm;
            comment.UpdateTime = DateTime.Now;
            _context.SaveChanges();

            var commentState = comment.IsConfirm == true ? "منتشر شده" : "منتشر نشده";

            return new ResultDto
            {
                IsSuccess = true,
                Message = $"وضعیت انتشار کامنت به {commentState} تغییر کرد"
            };
        }
    }
}
