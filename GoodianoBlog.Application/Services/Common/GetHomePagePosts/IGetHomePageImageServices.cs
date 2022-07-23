using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Common.GetHomePagePosts
{
    public interface IGetHomePageImageServices
    {
        ResultDto<List<GetHomePageImageDto>> Execute();
    }
}
