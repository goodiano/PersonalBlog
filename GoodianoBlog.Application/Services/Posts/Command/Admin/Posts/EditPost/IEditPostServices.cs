using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.EditPost
{
    public interface IEditPostServices
    {
        ResultDto Execute(RequestEditPost request);
    }
}
