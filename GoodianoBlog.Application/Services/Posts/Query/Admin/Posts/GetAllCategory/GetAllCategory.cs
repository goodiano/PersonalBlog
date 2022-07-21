using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllCategory
{
    public class GetAllCategory : IGetAllCategory
    {
        private readonly IDataBaseContext _context;
        public GetAllCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetAllCategoryDto>> Execute()
        {
            var category = _context.PostCategories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new GetAllCategoryDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}"
                }).ToList();

            return new ResultDto<List<GetAllCategoryDto>>
            {
                Data = category,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
