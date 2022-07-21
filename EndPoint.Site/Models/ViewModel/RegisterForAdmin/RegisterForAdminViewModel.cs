using GoodianoBlog.Application.Services.Users.Command.SignUpForAdmin;

namespace EndPoint.Site.Models.ViewModel.RegisterForAdmin
{
    public class RegisterForAdminViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int? Id { get; set; }
        public int Role { get; set; }
    }
}
