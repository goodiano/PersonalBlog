using Microsoft.AspNetCore.Http;

namespace GoodianoBlog.Application.Services.Posts.Query.Admin.Authors.GetAllAuthors
{
    public class ResultGetAllAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }      
    }
}
