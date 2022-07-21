using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Command.SignUp
{
    public interface ISignUpServices
    {
        ResultDto<SignUpUserDto> Execute(RequestSignUpUserDto request);
    }
}
