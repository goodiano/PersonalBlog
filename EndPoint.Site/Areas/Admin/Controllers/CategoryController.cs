using EndPoint.Site.Areas.Admin.Models.ViewModel;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.AddCategory;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.DeleteCategory;
using GoodianoBlog.Application.Services.Posts.Command.Admin.Categories.EditCategory;
using GoodianoBlog.Application.Services.Posts.Query.Admin.Categories.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IAddNewCategory _newCategory;
        private readonly IGetCategoryServices _getCategory;
        private readonly IDeleteCategoryServices _deleteCategory;
        private readonly IEditCategoryServices _editCategory;
        public CategoryController
        (
            IAddNewCategory newCategory,
            IGetCategoryServices getCategory,
            IDeleteCategoryServices deleteCategory,
            IEditCategoryServices editCategory
        )
        {
            _newCategory = newCategory;
            _getCategory = getCategory;
            _deleteCategory = deleteCategory;
            _editCategory = editCategory;
        }
        public IActionResult Index(int? parentId)
        {
            return View(_getCategory.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddCategory(int? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(int? parentId, string name)
        {
            var result = _newCategory.Execute(parentId, name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_deleteCategory.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel request)
        {
            var result = _editCategory.Execute(new RequestEditCategoryDto
            {
                Id = request.Id,
                Name = request.Name,
            });
            return Json(result);
        }
    }
}
