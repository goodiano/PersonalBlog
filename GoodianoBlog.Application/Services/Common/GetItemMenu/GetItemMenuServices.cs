using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Common.GetItemMenu
{
    public class GetItemMenuServices : IGetItemMenuServices
    {
        private readonly IDataBaseContext _context;
        public GetItemMenuServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetItemMenuDto>> Execute()
        {
            var category = _context.PostCategories
                .Include(p => p.ParentCategory)
                .Include(p=> p.SubCategory)
                .ToList()
                .Select(p => new GetItemMenuDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Child = p.SubCategory.ToList()
                    .Select(child => new GetItemMenuDto
                    {
                        Id = child.Id,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<GetItemMenuDto>>
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}
