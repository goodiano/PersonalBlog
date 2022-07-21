using GoodianoBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class CommentReplay : BaseEntity
    {
        public string Context { get; set; }
        public string Email { get; set; }
        public bool IsConfirm { get; set; }
        public string UserName { get; set; }
        public Comment Comments { get; set; }
        public int CommentsId { get; set; }
    }
}
