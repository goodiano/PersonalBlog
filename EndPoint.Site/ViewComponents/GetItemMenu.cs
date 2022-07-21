using GoodianoBlog.Application.Services.Common.GetItemMenu;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class GetItemMenu : ViewComponent
    {
        private readonly IGetItemMenuServices _getMenu;
        public GetItemMenu(IGetItemMenuServices getMenu)
        {
            _getMenu = getMenu;
        }

        public IViewComponentResult Invoke()
        {
            var menu = _getMenu.Execute();
            return View(viewName: "GetItemMenu", menu.Data);
        }
    }
}
