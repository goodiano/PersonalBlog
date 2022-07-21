using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.DeletePost
{
    public class DeletePostServices : IDeletePostServices
    {
        private readonly IDataBaseContext _context;
        public DeletePostServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var post = _context.Posts.Find(Id);
            post.RemoveTime = DateTime.Now;
            post.IsRemoved = true;

            _context.SaveChanges();


            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
