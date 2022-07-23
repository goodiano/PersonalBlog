using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.HomePage.Query.GetSliders
{
    public interface IGetSliderServices
    {
        ResultDto<List<GetSliderDto>> Execute();
    }
}
