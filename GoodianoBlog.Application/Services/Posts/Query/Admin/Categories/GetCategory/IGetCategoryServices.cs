using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Categories.GetCategory
{
    public interface IGetCategoryServices
    {
        ResultDto<List<GetCategoryDto>> Execute(int? parentId);
    }
}
