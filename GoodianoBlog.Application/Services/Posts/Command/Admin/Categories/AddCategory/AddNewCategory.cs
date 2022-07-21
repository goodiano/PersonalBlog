using GoodianoBlog.Application.Interfaces.Contexts;
using GoodianoBlog.Common.Dto;
using GoodianoBlog.Domain.Entities.Posts;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.AddCategory
{
    public class AddNewCategory : IAddNewCategory
    {
        private readonly IDataBaseContext _context;
        public AddNewCategory(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int? ParentId, string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام دسته بندی را وارد کنید"
                };
            }

            PostCategory category = new PostCategory()
            {
                Name = Name,
                ParentCategory = GetParentId(ParentId)
            };

            _context.PostCategories.Add(category);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
        }
        private PostCategory GetParentId(int? parentId)
        {
            return _context.PostCategories.Find(parentId);
        }


    }
}

