using GoodianoBlog.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.ClientSide.AddComment
{
    public interface IAddCommentsServices
    {
        ResultDto<AddCommentsDto> Execute(RequestAddComments request);
    }
}
