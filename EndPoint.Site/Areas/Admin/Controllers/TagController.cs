using GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.AddTag;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.DeleteTag;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Tags.GetAllTags;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly IAddTagServices _addTag;
        private readonly IGetAllTagsServices _getAllTag;
        private readonly IDeleteTagServices _deleteTag;
        public TagController(IAddTagServices addTag , IGetAllTagsServices getAllTag , IDeleteTagServices deleteTag)
        {
            _addTag = addTag;
            _getAllTag = getAllTag;
            _deleteTag = deleteTag;
        }
        public IActionResult Index()
        {
            return View(_getAllTag.Execute().Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            var result = _addTag.Execute(name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_deleteTag.Execute(Id));
        }



    }
}
