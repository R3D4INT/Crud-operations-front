using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.User
{
    public class EditViewModel : ILocalizableViewModel
    {
        public string EditOperation { get; set; }
        public string User { get; set; }
        public string BackToList { get; set; }
        public string SuccessfulResult { get; set; }
        public string ValidationError { get; set; }
        public string Error { get; set; }
        public string ErrorOccured { get; set; }
    }
}