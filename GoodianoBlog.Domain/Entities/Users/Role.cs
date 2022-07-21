using GoodianoBlog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Users
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        //Navigation
        public virtual ICollection<UserInRole> UserInRoles { get; set; }

    }
}
