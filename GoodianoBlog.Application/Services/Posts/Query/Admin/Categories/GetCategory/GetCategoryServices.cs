using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Categories.GetCategory
{
    public class GetCategoryServices : IGetCategoryServices
    {
        private readonly IDataBaseContext _context;
        public GetCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetCategoryDto>> Execute(int? parentId)
        {
            var result = _context.PostCategories
                .Include(p=> p.ParentCategory)
                .Include(p=> p.SubCategory)
                .Where(p=> p.ParentCategoryId == parentId)
                .ToList()
                .Select(p=> new GetCategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name
                    }
                    : null,
                    HasChild = p.SubCategory.Count() > 0 ? true : false  
                }).ToList();

            return new ResultDto<List<GetCategoryDto>>
            {
                Data = result,
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد"
            };
        }
    }
}
