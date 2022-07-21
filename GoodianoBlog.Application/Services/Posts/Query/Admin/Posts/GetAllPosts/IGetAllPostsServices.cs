using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllPosts
{
    public interface IGetAllPostsServices
    {
        ResultDto<List<ResultGetAllPostsDto>> Execute();
    }
}
