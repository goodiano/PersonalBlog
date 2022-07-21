using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class PostCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual PostCategory ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<PostCategory> SubCategory { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
