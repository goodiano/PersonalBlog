using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin
{
    public interface IGetAllUserServices
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}
