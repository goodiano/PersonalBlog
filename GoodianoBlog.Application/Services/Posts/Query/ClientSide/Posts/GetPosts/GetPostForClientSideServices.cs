using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts
{
    public class GetPostForClientSideServices : IGetPostForClientSideServices
    {
        private readonly IDataBaseContext _context;
        public GetPostForClientSideServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetPostForClientSideDto> Execute(Ordering ordering,string SearchKey, int Page, int? CatId)
        {
            int totalRow = 0;
            var postCategory = _context.Posts
                .Include(p => p.Images)
                .Include(p=> p.PostCategories)
                .Include(p=> p.Author).AsQueryable();

            if(CatId != null)
            {
                postCategory = postCategory.Where(p => p.PostCategoriesId == CatId).AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                postCategory = postCategory.Where(p => p.Title.Contains(SearchKey) || p.Content.Contains(SearchKey)).AsQueryable();
            }

            var post = postCategory.ToPaged(Page, 10, out totalRow);


            switch (ordering)
            {

                case Ordering.NotOrder:
                    postCategory = postCategory.OrderByDescending(p => p.Id).AsQueryable();
                    break;

                case Ordering.MostPopular:
                    postCategory = postCategory.OrderBy(p => p.CountView).AsQueryable();
                    break;

                case Ordering.theNewest:
                    postCategory = postCategory.OrderByDescending(p => p.Id).AsQueryable();
                    break;

            }


            return new ResultDto<GetPostForClientSideDto>
            {
                Data = new GetPostForClientSideDto
                {
                    TotalRow = totalRow,
                    LastPost = post.OrderByDescending(p=> p.Id).FirstOrDefault(),
                    Posts = post.Select(p => new PostsInClientSideDto
                    {
                        Id = p.Id,
                        Author = p.Author.Name,
                        Date = p.InsertTime,
                        ImageSrc = p.FirstSlideSrc,
                        Title = p.Title,
                        Category = p.PostCategories.Name
                    }).ToList()
                },
                IsSuccess = true,
            };


        }
    }
}
