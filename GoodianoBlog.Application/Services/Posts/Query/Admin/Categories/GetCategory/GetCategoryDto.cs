namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Categories.GetCategory
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }
}
