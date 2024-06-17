using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.User
{
    public class UserViewModel : ILocalizableViewModel
    {
        public string UserOperationsTitle { get; set; }
        public string Add { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
    }
}