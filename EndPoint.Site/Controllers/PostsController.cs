using EndPoint.Site.Models.ViewModel.Comments;
using GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostDetail;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class PostsController : Controller
    {
        private readonly IGetPostForClientSideServices _getPost;
        private readonly IGetPostDetailServices _getDetailPost;
        private readonly IAddCommentsServices _addComment;
        public PostsController(
            IGetPostForClientSideServices getPost ,
            IGetPostDetailServices getDetailPost,
            IAddCommentsServices addComment)
        {
            _getPost = getPost;
            _getDetailPost = getDetailPost;
            _addComment = addComment;          
        }

        public IActionResult Index(Ordering ordering,string SearchKey, int Page = 1, int? CatId = null)
        {
            return View(_getPost.Execute(ordering, SearchKey, Page,CatId).Data);
        }

        [HttpGet]
        public IActionResult Detail(int Id)
        {
            return View(_getDetailPost.Execute(Id).Data);
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel request)
        {
            var result = _addComment.Execute(new RequestAddComments
            {
                UserName = request.UserName,
                Email = request.Email,
                PostId = request.PostId,
                Context = request.Context,
            });
            return Json(result);
        }
    }
}
