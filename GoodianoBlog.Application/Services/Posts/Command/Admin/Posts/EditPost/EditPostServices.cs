using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.EditPost
{
    public class EditPostServices : IEditPostServices
    {
        private readonly IDataBaseContext _context;
        public EditPostServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditPost request)
        {
            var post = _context.Posts.Find(request.Id);
                
            var author = _context.Authors.Find(request.Author);
            var postCategory = _context.PostCategories.Find(request.PostCategory);


            post.Title = request.Title;
            post.Time = request.Time;
            post.Author = author;
            post.PostCategories = postCategory;
            post.FirstSlideSrc = request.FirstSlideSrc;
            post.Content = request.Content;
            post.UpdateTime = DateTime.Now;

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویرایش با موفقیت انجام شد"
            };
                
        }
    }
}
