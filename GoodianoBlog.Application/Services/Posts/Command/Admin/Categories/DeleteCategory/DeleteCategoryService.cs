using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.DeleteCategory
{
    public class DeleteCategoryService : IDeleteCategoryServices
    {
        private readonly IDataBaseContext _context;
        public DeleteCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int id)
        {
            var category = _context.PostCategories.Find(id);
            
            if (category.ParentCategoryId == null)
            {
                var result = _context.PostCategories
                   .OrderBy(p => p.Id)
                   .Include(p => p.SubCategory)
                   .First();

                _context.PostCategories.Remove(result);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "دسته بندی با موفقیت حذف شد"
                };
            }
            else
            {
                if(category.ParentCategoryId != null)
                {
                    _context.PostCategories.Remove(category);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "دسته بندی با موفقیت حذف شد"
                    };
                }
            }

            return new ResultDto
            {
                IsSuccess = false,
                Message = "حذف موفقیت آمیز نبود"
            };
        }
    }
}
