using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Common.HashPassword;
using Microsoft.EntityFrameworkCore;

namespace GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn
{
    public class LogInUserServices : ILogInUserServices
    {
        private readonly IDataBaseContext _context;
        public LogInUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<LogInUserDto> Execute(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<LogInUserDto>
                {
                    Data = new LogInUserDto
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "ایمیل و رمز عبور را وارد نمایید"
                };
            }

            var user = _context.Users
                .Include(p => p.UserInRoles)
                .ThenInclude(p => p.Roles)
                .Where(p => p.Email.Equals(Email)
                 && p.IsActive == true)
                .FirstOrDefault();

            if (user == null)
            {
                return new ResultDto<LogInUserDto>
                {
                    Data = new LogInUserDto
                    {
                        Id = 0,
                    },
                    IsSuccess = false,
                    Message = "ایمیل وجود ندارد؛ ابتدا ثبت نام کنید"
                };
            }

            PasswordHasher passwordHasher = new PasswordHasher();
            bool VerifyHashedPassword = passwordHasher.VerifyPassword(user.Password, Password);
            if (VerifyHashedPassword == false)
            {
                return new ResultDto<LogInUserDto>
                {
                    Data = new LogInUserDto
                    {
                        Id = 0,
                    },
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه است"
                };
            }

            List<string> roles = new List<string>();
            foreach (var item in user.UserInRoles)
            {
                roles.Add(item.Roles.RoleName);
            }

            return new ResultDto<LogInUserDto>
            {
                Data = new LogInUserDto
                {
                    Roles = roles,
                    Id = user.Id,
                    UserName = user.UserName,
                },
                IsSuccess = true,
                Message = "با موفقیت وارد شدید"
            };
        }
    }
}
