using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Common.HashPassword;
using GoodianoBlog.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GoodianoBlog.Application.Services.Users.Command.SignUp
{
    public class SignUpServices : ISignUpServices
    {
        private readonly IDataBaseContext _context;
        public SignUpServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<SignUpUserDto> Execute(RequestSignUpUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا نام کاربری را وارد کنید"
                    };
                }

                if (request.UserName.Length > 100)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "نام کاربری بیش از حد طولانی است"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا ایمیل را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا رمز عبور را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "لطفا تکرار رمز عبور را وارد کنید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن با یکدیگر تطابق ندارد"
                    };
                }


                string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
                var Passwordmatch = Regex.Match(request.Password, PasswordRegex);
                if (!Passwordmatch.Success)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور باید شامل حداقل یک کاراکتر بزرگ و کوچک لاتین باشد"
                    };
                }


                string EmailRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
                var Emailmatch = Regex.Match(request.Email, EmailRegex);
                if (!Emailmatch.Success)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل را به درستی وارد کنید"
                    };
                }

                string PhoneRegex = @"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$";
                var Phonematch = Regex.Match(request.PhonNumber, PhoneRegex);
                if (!Phonematch.Success)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره همراه را به درستی وارد کنید"
                    };
                }

                if (request.PhonNumber.Length > 11)
                {
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
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
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
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
                    return new ResultDto<SignUpUserDto>()
                    {
                        Data = new SignUpUserDto
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
                    var role = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    });
                }
                user.UserInRoles = userInRoles;

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<SignUpUserDto>
                {
                    Data = new SignUpUserDto
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام با موفقیت انجام شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto<SignUpUserDto>
                {
                    Data = new SignUpUserDto
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد"
                };

            }


        }

    }
}
