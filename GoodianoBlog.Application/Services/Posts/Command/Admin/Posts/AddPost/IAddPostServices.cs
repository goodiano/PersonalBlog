using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost
{
    public interface IAddPostServices
    {
        ResultDto Execute(RequestAddPostDto request);
    }
}
