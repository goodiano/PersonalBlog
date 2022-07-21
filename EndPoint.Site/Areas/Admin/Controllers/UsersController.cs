using EndPoint.Site.Models.ViewModel.EditInAdmin;
using EndPoint.Site.Models.ViewModel.RegisterForAdmin;
using GoodianoBlog.Application.Services.Users.Command.Admin.ChangeStatusInAdmin;
using GoodianoBlog.Application.Services.Users.Command.Admin.DeleteUserInAdmin;
using GoodianoBlog.Application.Services.Users.Command.Admin.EditUserInAdmin;
using GoodianoBlog.Application.Services.Users.Command.SignUpForAdmin;
using GoodianoBlog.Application.Services.Users.Query.GetAllUserForAdmin;
using GoodianoBlog.Application.Services.Users.Query.GetRolesForAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IGetAllUserServices _getAllUserServices;
        private readonly IGetRolesServices _getRoles;
        private readonly ISignUpForAdminServices _signUpForAdmin;
        private readonly IDeleteUserServices _deleteUserServices;
        private readonly IUserEditServices _userEditServices;
        private readonly IChangeStatusServices _changeStatusServices;

        public UsersController(
            IGetAllUserServices getAllUserServices,
            IGetRolesServices getRoles,
            ISignUpForAdminServices signUpForAdmin,
            IDeleteUserServices deleteUserServices,
            IUserEditServices userEditServices,
            IChangeStatusServices changeStatusServices)
        {
            _getAllUserServices = getAllUserServices;
            _getRoles = getRoles;
            _signUpForAdmin = signUpForAdmin;
            _deleteUserServices = deleteUserServices;
            _userEditServices = userEditServices;
            _changeStatusServices = changeStatusServices;
        }

        public IActionResult Index(string searchkey, int page)
        {
            var result = _getAllUserServices.Execute(new RequestGetUserDto
            {
                SearchKey = searchkey,
                Page = page
            });
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Roles = new SelectList(_getRoles.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegisterForAdminViewModel request)
        {
            var result = _signUpForAdmin.Execute(new RequestSignUpForAdminDto
            {
                UserName = request.UserName,
                Email = request.Email,
                PhonNumber = request.PhoneNumber,                
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RoleUserDto>()
                {
                    new RoleUserDto()
                    {
                        Id = request.Role,
                    }
                },
            });
            return Json(result);
        }

       
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            return Json(_deleteUserServices.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel request)
        {
            return Json(_userEditServices.Execute(new RequsteUserEditDto
            {
                Id= request.Id,
                UserName = request.UserName,
                Email = request.Email,
                PhonNumber = request.PhonNumber,
                Password = request.Password,
                RePassword = request.RePassword,                
            }));
        }

        [HttpPost]
        public IActionResult ChangeStatus(int Id)
        {
            return Json(_changeStatusServices.Execute(Id));
        }
    }
}
