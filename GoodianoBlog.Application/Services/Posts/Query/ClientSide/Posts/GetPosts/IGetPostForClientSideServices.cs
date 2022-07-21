using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Query.ClientSide.Posts.GetPosts
{
    public interface IGetPostForClientSideServices
    {
        ResultDto<GetPostForClientSideDto> Execute(Ordering ordering, string SearchKey, int Page, int? CatId);
    }


    public enum Ordering
    {
        NotOrder = 0,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular = 1,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest = 2,
    }

}
