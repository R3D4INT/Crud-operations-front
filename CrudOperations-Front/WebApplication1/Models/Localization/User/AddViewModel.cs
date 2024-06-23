using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.User
{
    public class AddViewModel : ILocalizableViewModel
    {
        public string AddOperation { get; set; }
        public string User { get; set; }
        public string Back { get; set; }
        public string SuccessfulAdding { get; set; }
        public string ErrorOccured { get; set; }
        public string Create {  get; set; }
    }
}