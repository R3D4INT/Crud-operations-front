using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.Home
{
    public class ContactViewModel : ILocalizableViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Support { get; set; }
        public string Marketing { get; set; }
    }
}