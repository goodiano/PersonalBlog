using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Command.Admin.DeleteUserInAdmin
{
    public interface IDeleteUserServices
    {
        ResultDto Execute(int Id);
    }
}
