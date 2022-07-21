using GoodianoBlog.Application.Services.Users.Command.SignUp;
using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builder;
using Xunit;

namespace UnitTest.Core.Application
{
    public class SignUp
    {
        [Fact]
        public void Add_WhenAllFieldsInAddArePopulated_AddUserToDataBase()
        {
            //Arrange
            var dataBaseBuilder = new DataBaseBuilder();
            var dbContext = dataBaseBuilder.GetDbContext();


            //Act
            var service = new SignUpServices(dbContext);

            var result =  service.Execute(new RequestSignUpUserDto()
            {
                UserName = "Hossein",
                Email = "Hosseingoody@gmail.com",
                PhonNumber = "09226966987",
                Password = "136754744Hos",
                RePassword = "136754744Hos"
            });

            var same = service.Execute(new RequestSignUpUserDto()
            {
                UserName = "Hadi",
                Email = "Hadi@gmail.com",
                PhonNumber = "09126966987",
                Password = "135754744Hos",
                RePassword = "135754744Hos"
            });


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ResultDto<SignUpUserDto>>(result);
            Assert.NotSame(result, same);
        }



    }
}
