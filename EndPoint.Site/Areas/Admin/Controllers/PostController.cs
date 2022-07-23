using EndPoint.Site.Models.ViewModel.EditPost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.DeletePost;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.EditPost;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Authors.GetAllAuthors;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllCategory;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllPosts;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Tags.GetAllTags;
using GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostForEdit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IAddPostServices _addPost;
        private readonly IGetAllCategory _getAllCategory;
        private readonly IGetAllAuthorServices _getAllAuthor;
        private readonly IHostingEnvironment _env;
        private readonly IGetAllPostsServices _getAllPost;
        private readonly IDeletePostServices _deletePost;
        private readonly IEditPostServices _editPost;
        private readonly IGetPostForEditServices _getPostForEdit;
        private readonly IGetAllTagsServices _getAllTag;
        public PostController
            (IAddPostServices addPost,
            IGetAllCategory getAllCategory, 
            IGetAllAuthorServices getAllAuthor,
            IHostingEnvironment env ,
            IGetAllPostsServices getAllPost,
            IDeletePostServices deletePost,
            IEditPostServices editPost,
            IGetPostForEditServices getPostForEdit,
            IGetAllTagsServices getAllTag)
        {
            _addPost = addPost;
            _getAllCategory = getAllCategory;
            _getAllAuthor = getAllAuthor;
            _env = env;
            _getAllPost = getAllPost;
            _deletePost = deletePost;
            _editPost = editPost;
            _getPostForEdit = getPostForEdit;
            _getAllTag = getAllTag;
        }


        [HttpPost]
        public async Task<IActionResult> uploadImg(List<IFormFile> file)
        {
            string message;
            for (int i = 0; i< file.Count(); i++)
            {
                string fileName = DateTime.Now.Ticks.ToString() + file[i].FileName;
                var saveimg = Path.Combine(_env.WebRootPath, "image", fileName);
                string imgext = Path.GetExtension(fileName);

                if (imgext == ".jpg" || imgext == ".png")
                {
                    using (var uploadimg = new FileStream(saveimg, FileMode.Create))
                    {
                        await file[i].CopyToAsync(uploadimg);
                        message = "فایل انتخابی به نام" + fileName + " ذخیره شد";
                    }
                }
                else
                {
                    message = "فقط از فرمت های jpg و png ساپورت می شود";
                }
            }
            return Content("OK");
        }

        public IActionResult Index()
        {
            return View(_getAllPost.Execute().Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Tag = new SelectList(_getAllTag.Execute().Data, "Id", "Name");
            ViewBag.Author = new SelectList(_getAllAuthor.Execute().Data, "Id", "Name");
            ViewBag.Category = new SelectList(_getAllCategory.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(RequestAddPostDto request, IFormFile MainSlideSrc)
        {
            //در اینجا در حقیقت مجبور شدم تصویر اولی که از سمت ویو ارسال میشه رو به اسلاید اصلی اختصاص بدم
            //و خطایی رخ نمیده چرا که اسلاید اول نمی تواند خالی باشد و فقط هم یک تصویر قبول میکند
            List<IFormFile> SinglePhoto = new List<IFormFile>();
            List<IFormFile> files = Request.Form.Files.ToList();
            MainSlideSrc = files[0];


            string filepath1 = "";
            for (int i = 1; i < files.Count(); i++)
            {
                string fileName = DateTime.Now.Ticks.ToString() + files[i].FileName;
                string ServerMapPath = Path.Combine(_env.WebRootPath, fileName);
                using (var stream = new FileStream(ServerMapPath, FileMode.Create))
                {
                    files[i].CopyTo(stream);
                }
                filepath1 = "https://localhost:44336/" + "image/" + files[i].FileName;

                var image = files[i];
                SinglePhoto.Add(image);
            }

            List<IFormFile?> ImageGallery = new List<IFormFile?>();

            var filepath2 = "";
            for (int i = 10; i < files.Count(); i++)
            {
                string ServerMapPath = Path.Combine(_env.WebRootPath, "image", files[i].FileName);
                using (var stream = new FileStream(ServerMapPath, FileMode.Create))
                {
                    files[i].CopyTo(stream);
                }
                filepath2 = "https://localhost:44336/" + "image/" + files[i].FileName;
                var image = files[i];
                ImageGallery.Add(image);
            }


            request.ImageGallery = ImageGallery;
            request.SinglePhoto = SinglePhoto;
            request.MainSlideSrc = MainSlideSrc;
            return Json(_addPost.Execute(request));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Json(_deletePost.Execute(id));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var result = _getPostForEdit.Execute(Id).Data;
            ViewBag.Tag = new SelectList(_getAllTag.Execute().Data, "Id", "Name");
            ViewBag.Authors = new SelectList(_getAllAuthor.Execute().Data, "Id", "Name");
            ViewBag.Categories = new SelectList(_getAllCategory.Execute().Data, "Id", "Name");

            
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(EditPostViewModel request)
        {
            string filepath = "";
            for (int i = 0; i < Request.Form.Files.Count(); i++)
            {
                string ServerMapPath = Path.Combine(_env.WebRootPath, $@"image\FirstSlide\", Request.Form.Files[i].FileName);
                using (var stream = new FileStream(ServerMapPath, FileMode.Create))
                {
                    Request.Form.Files[i].CopyTo(stream);
                }
                filepath = $@"image\FirstSlide\" + Request.Form.Files[i].FileName;
                var image = Request.Form.Files[i];
            }

            var result = _editPost.Execute(new RequestEditPost
            {
                Id= request.Id,
                Title = request.Title,
                Time = request.Time,
                Author = request.AuthorId,              
                PostCategory = request.PostCategoryId,
                Tag = request.TagId,                
                Content = request.Content,
                FirstSlideSrc = filepath,
            });

            return Json(result);
        }
    }
}