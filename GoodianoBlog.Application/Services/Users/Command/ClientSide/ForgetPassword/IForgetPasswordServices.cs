using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Application.Services.Users.Command.ClientSide.ForgetPassword.EmailSender;
using GoodianoBlog.Application.Services.Users.Command.EmailSender;
using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn.ForgetPassword
{
    public interface IForgetPasswordServices
    {
        ResultDto Execute(string email);
    }

    public class ForgetPasswordServices : IForgetPasswordServices
    {
        private readonly IDataBaseContext _context;
        private readonly IViewRenderService _viewRender;
        public ForgetPasswordServices(IDataBaseContext context , IViewRenderService viewRender)
        {
            _context= context;
            _viewRender= viewRender;
        }
        public ResultDto Execute(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "فیلد ایمیل نمی تواند خالی باشد"
                };
            }
            var userEmail = _context.Users.Where(p=> p.Email == email).FirstOrDefault();
            if(userEmail == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شما در سایت ثبت نام نکرده اید"
                };
            }
            else
            {
                string bodyEmail = _viewRender.RenderToStringAsync("_forgotPassword", userEmail);
                SendEmail.Send(userEmail.Email, "بازیابی کلمه عبور", bodyEmail);
            }

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ایمیل بازیابی رمز عبور با موفقیت ارسال شد"
            };
        }
    }
}
