using GoodianoBlog.Application.Services.Users.Command.Admin.EditUserInAdmin;

namespace GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhonNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsActive { get; set; }
    }
}
