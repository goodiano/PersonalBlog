using GoodianoBlog.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Users.Command.SignUpForAdmin
{
    public interface ISignUpForAdminServices
    {
        ResultDto<SignUpForAdminDto> Execute(RequestSignUpForAdminDto request);
    }
}
