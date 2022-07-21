using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Users.Command.Admin.DeleteUserInAdmin
{
    public class DeleteUserServices : IDeleteUserServices
    {
        private readonly IDataBaseContext _context;
        public DeleteUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var user = _context.Users.Find(Id);
            if(user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر مورد نظر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر {user.UserName} با موفقیت حذف شد"
            };
        }
    }
}
