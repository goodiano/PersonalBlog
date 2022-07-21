using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class Image
    {
        public int Id{ get; set; }
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public string Src { get; set; }
    }
}
