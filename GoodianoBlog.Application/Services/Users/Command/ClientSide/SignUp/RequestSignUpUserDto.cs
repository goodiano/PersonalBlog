﻿namespace GoodianoBlog.Application.Services.Users.Command.SignUp
{
    public class RequestSignUpUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhonNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RoleUserDto> Roles { get; set; }
    }
}
