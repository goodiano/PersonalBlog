using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Common.HashPassword;
using GoodianoBlog.Domain.Entities.Users;
using System.Text.RegularExpressions;

namespace GoodianoBlog.Application.Services.Users.Command.SignUpForAdmin
{
    public class SignUpForAdminServices : ISignUpForAdminServices
    {
        private readonly IDataBaseContext _context;
        public SignUpForAdminServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<SignUpForAdminDto> Execute(RequestSignUpForAdminDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا نام کاربری را وارد کنید"
                    };
                }

                if (request.UserName.Length > 100)
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "نام کاربری بیش از حد طولانی است"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا ایمیل را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا رمز عبور را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا تکرار رمز عبور را وارد کنید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن با یکدیگر تطابق ندارد"
                    };
                }

                if (request.PhonNumber.Length > 11)
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره همراه را به درستی وارد کنید"
                    };
                }

                PasswordHasher passwordHasher = new PasswordHasher();
                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    PhonNumber = request.PhonNumber,
                    Password = passwordHasher.HashPassword(request.Password),
                    RePassword = passwordHasher.HashPassword(request.RePassword),
                    IsActive = true
                };

                var authenticateEmail = _context.Users.Select(p => p.Email).ToList();
                if (authenticateEmail.Contains(user.Email))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل وارد شده از قبل وجود دارد"
                    };
                }

                var authenticatePhone = _context.Users.Select(p => p.PhonNumber).ToList();
                if (authenticatePhone.Contains(user.PhonNumber))
                {
                    return new ResultDto<SignUpForAdminDto>()
                    {
                        Data = new SignUpForAdminDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره موبایل وارد شده از قبل وجود دارد"
                    };
                }

                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        RoleId = roles.Id,
                        UserId = user.Id
                    });
                }
                user.UserInRoles = userInRoles;

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<SignUpForAdminDto>
                {
                    Data = new SignUpForAdminDto
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام با موفقیت انجام شد"
                };
            }
            catch (Exception)
            {

                return new ResultDto<SignUpForAdminDto>
                {
                    Data = new SignUpForAdminDto
                    {
                        UserId = 0
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد"
                };
            }


        }
    }
}
