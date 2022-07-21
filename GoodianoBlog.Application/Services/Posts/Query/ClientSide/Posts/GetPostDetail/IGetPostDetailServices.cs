using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostDetail
{
    public interface IGetPostDetailServices
    {
        ResultDto<GetPostDetailDto> Execute(int Id);
    }
}
