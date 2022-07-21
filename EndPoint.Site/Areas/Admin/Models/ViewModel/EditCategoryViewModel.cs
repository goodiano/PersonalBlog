namespace EndPoint.Site.Areas.Admin.Models.ViewModel
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parent{ get; set; }
        public bool Child { get; set; }
    }
}
