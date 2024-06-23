using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.User
{
    public class DeleteViewModel : ILocalizableViewModel
    {
        public string DeleteOperation { get; set; }
        public string Confirmation { get; set; }
        public string User { get; set; }
        public string BackToList { get; set; }
        public string SuccessfulDeletion { get; set; }
        public string ErrorOccured { get; set; }
    }
}