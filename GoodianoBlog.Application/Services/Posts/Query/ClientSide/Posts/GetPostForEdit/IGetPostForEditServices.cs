using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPostForEdit
{
    public interface IGetPostForEditServices
    {
        ResultDto<GetPostForEditDto> Execute(int Id);
    }
}
