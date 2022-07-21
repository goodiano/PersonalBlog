using GoodianoBlog.Domain.Entities.Common;
using GoodianoBlog.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class Comment: BaseEntity
    {
        public string Context { get; set; }
        public string Email { get; set; }
        public bool IsConfirm { get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<CommentReplay>? CommentReplays { get; set; }
    }
}
