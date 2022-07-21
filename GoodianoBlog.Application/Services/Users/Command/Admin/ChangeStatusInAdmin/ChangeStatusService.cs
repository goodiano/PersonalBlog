using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Users.Command.Admin.ChangeStatusInAdmin
{
    public class ChangeStatusService : IChangeStatusServices
    {
        private readonly IDataBaseContext _context;
        public ChangeStatusService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var user = _context.Users.Find(Id);

            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "وضعیت کاربر تغییر یافت"
            };
        }
    }
}
