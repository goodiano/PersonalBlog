using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Users
{
    public class UserInRole
    {
        public int Id { get; set; }
        public virtual User Users { get; set; }
        public int UserId { get; set; }
        public virtual Role Roles { get; set; }
        public int? RoleId { get; set; }
    }
}
