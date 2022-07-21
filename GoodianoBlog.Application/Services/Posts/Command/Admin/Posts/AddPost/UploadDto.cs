using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Application.Services.Posts.Command.Admin.Posts.AddPost
{
    public class UploadDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
}
