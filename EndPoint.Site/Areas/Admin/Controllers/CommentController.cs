using GoodianoBlog.Application.Services.Posts.Command.Admin.Comments.ChangeStatus;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Comments.GetAllComments;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IGetAllCommentsServices _getAllComment;
        private readonly ICommentChangeStatusServices _statusChange;
        public CommentController(IGetAllCommentsServices getAllComment , ICommentChangeStatusServices statusChange)
        {
            _getAllComment = getAllComment;
            _statusChange = statusChange;
        }
        public IActionResult Index()
        {
            return View(_getAllComment.Execute().Data);
        }

        [HttpPost]
        public IActionResult CommentSatusChange(int Id)
        {
            return Json(_statusChange.Execute(Id));
        }
    }
}
