using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.AddCategory
{
    public interface IAddNewCategory
    {
        ResultDto Execute(int? ParentId, string Name);
    }
}

