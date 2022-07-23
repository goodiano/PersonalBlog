using GoodianoBlog.Application.Services.Common.GetHomePagePosts;
using GoodianoBlog.Application.Services.HomePage.Query.GetSliders;

namespace EndPoint.Site.Models.ViewModel.HomePages
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> GetSliders { get; set; }
        public List<GetHomePageImageDto> GetHomePageImages { get; set; }
    }
}
