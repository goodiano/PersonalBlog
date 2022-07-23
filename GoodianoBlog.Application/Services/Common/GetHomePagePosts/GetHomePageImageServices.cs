using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Common.GetHomePagePosts
{
    public class GetHomePageImageServices : IGetHomePageImageServices
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImageServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetHomePageImageDto>> Execute()
        {
            var homePage = _context.HomePageImages
                .OrderByDescending(p => p.Id)
                .Select(p => new GetHomePageImageDto
                {
                    Id = p.Id,
                    Author = p.Author,
                    Link = p.Link,
                    LocationImages = p.LocationImages,
                    Src = p.Src,
                    Tag = p.Tag,
                    Time = p.Time,
                    Title = p.Title,
                }).ToList();

            return new ResultDto<List<GetHomePageImageDto>>
            {
                Data = homePage,
                IsSuccess = true
            };
        }
    }
}
