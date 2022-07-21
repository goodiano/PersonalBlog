namespace GoodianoBlog.Application.Services.Common.GetItemMenu
{
    public class GetItemMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetItemMenuDto> Child { get; set; }
        //public List<GetItemMenuDto> Parent { get; set; }

    }
}
