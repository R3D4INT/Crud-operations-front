using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization.User
{
    public class UserAddCompositeViewModel : ILocalizableViewModel
    {
        public Models.User User { get; set; }
        public AddViewModel AddViewModel { get; set; }
    }
}