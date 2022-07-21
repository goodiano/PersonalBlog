﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodianoBlog.Domain.Entities.Posts
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
