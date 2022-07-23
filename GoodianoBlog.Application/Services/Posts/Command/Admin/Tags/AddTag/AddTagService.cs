using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.AddTag
{
    public class AddTagService : IAddTagServices
    {
        private readonly IDataBaseContext _context;
        public AddTagService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(string Name)
        {
            Tag tag = new Tag()
            {
                Name = Name
            };

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "تگ با موفقیت افزوده شد"
            };
        }
    }
}
