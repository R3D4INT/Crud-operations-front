using WebApplication1.Models.Localization.Interfaces;
using WebApplication1.Models.Localization.User;

namespace WebApplication1.Models.Localization.CompositeViewsModels
{
    public class UserEditCompositeViewModel : ILocalizableViewModel
    {
        public Models.User User { get; set; }
        public EditViewModel EditViewModel { get; set; }
    }
}