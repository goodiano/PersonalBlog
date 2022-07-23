using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Tags.GetAllTags
{
    public class GetAllTagsService : IGetAllTagsServices
    {
        private readonly IDataBaseContext _context;
        public GetAllTagsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetAllTagsDto>> Execute()
        {
            var tags = _context.Tags
                .OrderByDescending(p => p.Id)
                .Select(p => new GetAllTagsDto
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

            return new ResultDto<List<GetAllTagsDto>>
            {
                Data = tags,
                IsSuccess = true,
            };
        }
    }

}
