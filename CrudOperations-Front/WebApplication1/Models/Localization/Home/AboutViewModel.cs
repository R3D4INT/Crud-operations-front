using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization
{
    public class AboutViewModel : ILocalizableViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Introduction { get; set; }
    }
}