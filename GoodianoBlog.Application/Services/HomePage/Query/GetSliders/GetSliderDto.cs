namespace GoodianoBlog.Application.Services.HomePage.Query.GetSliders
{
    public class GetSliderDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public DateTime Time { get; set; }
    }
}
