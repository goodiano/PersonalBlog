using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.EditCategory
{
    public class EditCategoryServices : IEditCategoryServices
    {
        private readonly IDataBaseContext _context;
        public EditCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditCategoryDto request)
        {
            var category = _context.PostCategories.Find(request.Id);
            category.Name = request.Name;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات ویرایش موفقیت آمیز بود"
            };
        }
    }
}
