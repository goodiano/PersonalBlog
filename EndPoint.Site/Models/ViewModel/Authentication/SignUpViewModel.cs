using GoodianoBlog.Application.Services.Users.Command.SignUp;

namespace EndPoint.Site.Models.ViewModel.Authentication
{
    public class SignUpViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhonNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int? Id { get; set; }
        public List<RoleUserDto>? Role { get; set; }
    }
}
