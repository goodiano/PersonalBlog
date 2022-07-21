using GoodianoBlog.Domain.Entities.Posts;

namespace EndPoint.Site.Models.ViewModel.EditPost
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Time { get; set; }
        public int PostCategoryId { get; set; }
        public string FirstSlideSrc { get; set; }                 
        public string Content { get; set; }                 
       
    }
}
