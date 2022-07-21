using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment
{
    public class AddCommentsService : IAddCommentsServices
    {
        private readonly IDataBaseContext _context;
        public AddCommentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<AddCommentsDto> Execute(RequestAddComments request)
        {

            if (request.UserName == null)
            {
                return new ResultDto<AddCommentsDto>
                {
                    Data = new AddCommentsDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "لطفا نام کاربری خود را وارد کنید"
                };
            }

            if (request.Email == null)
            {
                return new ResultDto<AddCommentsDto>
                {
                    Data = new AddCommentsDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "لطفا ایمیل را وارد کنید"
                };
            }

            if (request.Context == null)
            {
                return new ResultDto<AddCommentsDto>
                {
                    Data = new AddCommentsDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "محتوای پیام شما نمی تواند خالی باشد"
                };
            }

            Comment comment = new Comment()
            {
                Email = request.Email,
                Context = request.Context,
                IsConfirm = false,
                UserName = request.UserName,
                PostId = request.PostId,
                InsertTime = DateTime.Now,
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();


            return new ResultDto<AddCommentsDto>
            {
                Data = new AddCommentsDto()
                {
                    UserName = comment.UserName,
                    Email = comment.Email,
                    PostId = comment.PostId,
                    Context = comment.Context,      
                },
                IsSuccess = true,
                Message = "پیام شما ثبت شد و پس از تایید منتشر خواهد شد"
            };
        }
    }
}
