namespace GoodianoBlog.Application.Services.Users.Command.ClientSide.LogIn
{
    public class LogInUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
