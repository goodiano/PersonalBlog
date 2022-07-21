using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;

namespace GoodianoBlog.Application.Services.Users.Query.GetRolesForAdmin
{
    public class GetRolesServices : IGetRolesServices
    {
        private readonly IDataBaseContext _context;
        public GetRolesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetRolesDto>> Execute()
        {
            var roles = _context.Roles.Select(p => new GetRolesDto
            {
                Id = p.Id,
                Name = p.RoleName
            }).ToList();

            return new ResultDto<List<GetRolesDto>>
            {
                Data = roles,
                IsSuccess = true,
            };
        }
    }
}
