using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Authors.GetAllAuthors
{
    public class GetAllAuthorServices : IGetAllAuthorServices
    {
        private readonly IDataBaseContext _context;
        public GetAllAuthorServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<ResultGetAllAuthorDto>> Execute()
        {
            var result = _context.Authors
                .Select(p => new ResultGetAllAuthorDto
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList();

            return new ResultDto<List<ResultGetAllAuthorDto>>
            {
                Data = result,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
