using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Posts.GetAllCategory
{
    public interface IGetAllCategory
    {
        ResultDto<List<GetAllCategoryDto>> Execute();
    }
}
