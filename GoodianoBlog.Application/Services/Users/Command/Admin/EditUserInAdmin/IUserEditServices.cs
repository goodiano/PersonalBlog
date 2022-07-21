using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Command.Admin.EditUserInAdmin
{
    public interface IUserEditServices
    {
        ResultDto Execute(RequsteUserEditDto requeste);
    }
}
