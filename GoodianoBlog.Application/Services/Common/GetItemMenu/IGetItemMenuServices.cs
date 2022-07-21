using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Common.GetItemMenu
{
    public interface IGetItemMenuServices
    {
        ResultDto<List<GetItemMenuDto>> Execute();
    }
}
