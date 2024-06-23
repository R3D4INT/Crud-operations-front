using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.Shared
{
    public class LayoutViewModel : ILocalizableViewModel
    {
        public string Title { get; set; }
        public string Front { get; set; }
        public string Home { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
        public string CrudOperations { get; set; }
    }
}