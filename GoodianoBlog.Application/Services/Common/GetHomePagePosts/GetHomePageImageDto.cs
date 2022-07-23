using GoodianoBlog.Domain.Entities.HomePage.HomePageImages;

namespace GoodianoBlog.Application.Services.Common.GetHomePagePosts
{
    public class GetHomePageImageDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public DateTime Time { get; set; }
        public LocationImages LocationImages { get; set; }
    }
}
