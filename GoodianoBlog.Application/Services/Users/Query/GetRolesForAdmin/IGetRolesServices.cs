using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Query.GetRolesForAdmin
{
    public interface IGetRolesServices
    {
        ResultDto<List<GetRolesDto>> Execute();
    }
}
