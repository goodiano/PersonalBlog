using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.DeleteTag
{
    public class DeleteTagService : IDeleteTagServices
    {
        private readonly IDataBaseContext _context;
        public DeleteTagService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var tag = _context.Tags.Find(Id);

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "حذف با موفقیت انجام شد"
            };
        }
    }
}
