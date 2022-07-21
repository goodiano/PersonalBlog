using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Comments.ChangeStatus
{
    public interface ICommentChangeStatusServices
    {
        ResultDto Execute(int Id);
    }
}
