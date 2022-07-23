using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Tags.AddTag
{
    public interface IAddTagServices
    {
        ResultDto Execute(string Name);
    }
}
