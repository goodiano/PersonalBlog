using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Pagination;

namespace GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin
{
    public class GetAllUserServices : IGetAllUserServices
    {
        private readonly IDataBaseContext _context;
        public GetAllUserServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            //Create Query
            var users = _context.Users.AsQueryable();

            //Config SearchBar
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
               users.Where(p => p.UserName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));                
            }

            //Pagination And Select User 
            int rowCount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowCount).Select(p => new GetUserDto
            {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email,
                PhonNumber = p.PhonNumber,
                Password = p.Password,
                RePassword = p.RePassword,
                IsActive = p.IsActive
            }).ToList();

            return new ResultGetUserDto
            {
                ListUsers = usersList,
                Rows = rowCount
            };
        }
    }
}
