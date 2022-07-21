using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class ImageGallery
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
        public int ImageGalleriesId { get; set; }
        public virtual Post Posts { get; set; }
        public int PostId { get; set; }
    }
}
