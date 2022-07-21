namespace GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin
{
    public class ResultGetUserDto
    {
        public List<GetUserDto> ListUsers { get; set; }
        public int Rows { get; set; }
    }
}
