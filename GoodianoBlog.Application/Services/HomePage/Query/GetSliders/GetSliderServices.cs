using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.HomePage.Query.GetSliders
{
    public class GetSliderServices : IGetSliderServices
    {
        private readonly IDataBaseContext _context;
        public GetSliderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetSliderDto>> Execute()
        {
            var sliders = _context.Sliders
                .OrderByDescending(p => p.Id)
                .Select(p => new GetSliderDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    Link = p.Link,
                    Src = p.Src,
                    Tag = p.Tag,
                    Time = p.Time
                }).ToList();

            return new ResultDto<List<GetSliderDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
