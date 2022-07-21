using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Comments.GetAllComments
{
    public interface IGetAllCommentsServices
    {
        ResultDto<List<GetAllCommentDto>> Execute();
    }
}
