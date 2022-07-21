using EndPoint.Site.Controllers;
using EndPoint.Site.Models.ViewModel.Authentication;
using GoodianoBlog.Application.Services.Users.Command.SignUp;
using GoodianoBlog.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Presentation.Controller
{
    //public class AuthenticationContollerTest
    //{
    //    [Fact]
    //    public void SignUpController_Test()
    //    {
    //        //Arrange
             
    //        var moq = new Mock<ISignUpServices>();
    //        var user = new ClaimsPrincipal(new ClaimsIdentity());           
    //        AuthenticationContoller controller = new AuthenticationContoller(moq.Object);
    //        controller.ControllerContext = new ControllerContext();
    //        controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

    //        SignUpViewModel request = new SignUpViewModel()
    //        {
    //            Id= 65,
    //            UserName = "Hosein",
    //            Email = "Hossserein@gmail.com",
    //            Password = "136754744.Hossein",
    //            RePassword = "136754744.Hossein",
    //            PhoneNumber = "09226545789",
    //            Role = new List<RoleUserDto>
    //            {
    //                new RoleUserDto(){Id = 2}
    //            }
    //        };


    //        //Act
    //        var result = controller.SignUp(request);

    //        //Assert
    //        Assert.IsType<JsonResult>(result);
    //        //var JsonResult = result as JsonResult;
    //        //Assert.IsAssignableFrom<User>(JsonResult);
    //    }
    //}
}
