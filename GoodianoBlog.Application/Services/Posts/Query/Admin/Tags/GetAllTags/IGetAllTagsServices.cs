using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Tags.GetAllTags
{
    public interface IGetAllTagsServices
    {
        ResultDto<List<GetAllTagsDto>> Execute();
    }

}
