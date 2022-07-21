using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Domain.Entities.Posts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost
{
    public class AddPostServices : IAddPostServices
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _env;

        public AddPostServices(IDataBaseContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public ResultDto Execute(RequestAddPostDto request)
        {
            if (request.AuthorId == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام نویسنده را وارد کنید"
                };
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تیتر را وارد کنید"
                };
            }

            if (request.MainSlideSrc == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا اسلاید اصلی را انتخاب کنید"
                };
            }


            try
            {
                var category = _context.PostCategories.Find(request.CategoryId);
                Post post = new Post
                {
                    Title = request.Title,
                    AuthorId = request.AuthorId,
                    Time = request.Time,
                    Content = request.Content,
                    PostCategoriesId = category.Id
                };


                //آپلود اسلاید اصلی
                var mainSlide = UploadFile(request.MainSlideSrc);
                post.FirstSlideSrc = mainSlide.FileNameAddress;
                _context.Posts.Add(post);

 
                //آپلود تصاویر داخل پست
                List<Image> image = new List<Image>();
                //var images = UploadFile(item);
                foreach (var item in request.SinglePhoto)
                    image.Add(new Image
                    {
                        Post = post,
                        Src = item.FileName,
                    });

                _context.Images.AddRange(image);

                //آپلود گالری های داخل پست
                List<ImageGallery?> imageGallery = new List<ImageGallery?>();
                foreach (var item in request.ImageGallery)
                {
                    //var images = UploadFile(item);
                    imageGallery.Add(new ImageGallery
                    {
                        Posts = post,
                        Src = item.FileName,
                    });
                }

                _context.ImageGalleries.AddRange(imageGallery);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "پست با موفقیت ارسال شد"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "ارسال پست با شکست مواجه شد"
                };
            }
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"image\FirstSlide\";
                var uploadsRootFolder = Path.Combine(_env.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                if (file == null || file.Length == 0)
                {
                    return new UploadDto
                    {
                        Status = false,
                        FileNameAddress = ""
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new UploadDto
                {
                    FileNameAddress = folder + fileName,
                    Status = true
                };
            }

            return null;
        }
    }
}
