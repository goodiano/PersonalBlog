using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Common.HashPassword;

namespace GoodianoBlog.Application.Services.Users.Command.Admin.EditUserInAdmin
{
    public class UserEditService : IUserEditServices
    {
        private readonly IDataBaseContext _context;
        public UserEditService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequsteUserEditDto requeste)
        {
            var user = _context.Users.Find(requeste.Id);
           
            PasswordHasher passwordHasher = new PasswordHasher();
            user.UpdateTime = DateTime.Now;
            user.Id = requeste.Id;
            user.UserName = requeste.UserName;
            user.Email = requeste.Email;
            user.PhonNumber = requeste.PhonNumber;
            user.Password = passwordHasher.HashPassword(user.Password);
            user.RePassword = passwordHasher.HashPassword(requeste.RePassword);

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر {user.UserName} ویرایش شد"
            };
        }
    }
}
