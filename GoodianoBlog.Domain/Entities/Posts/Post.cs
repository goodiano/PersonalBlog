using GoodianoBlog.Domain.Entities.Common;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Time { get; set; }
        public string FirstSlideSrc { get; set; }
        public string Content { get; set; }
        public int CountView { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public virtual PostCategory PostCategories { get; set; }
        public int PostCategoriesId { get; set; }
        public virtual ICollection<ImageGallery?> ImageGalleries { get; set; }
        public virtual ICollection<Image?> Images { get; set; }
        public virtual ICollection<Comment?> Comments { get; set; }
        public virtual Tag Tag { get; set; }
        public int TagId { get; set; }
    }


}
