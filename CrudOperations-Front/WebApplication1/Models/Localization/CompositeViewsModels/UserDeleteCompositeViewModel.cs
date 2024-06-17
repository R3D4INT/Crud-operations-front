using WebApplication1.Models.Localization.Interfaces;
using WebApplication1.Models.Localization.User;

namespace WebApplication1.Models.Localization.CompositeViewsModels
{
    public class UserDeleteCompositeViewModel : ILocalizableViewModel
    {
        public Models.User User { get; set; }
        public DeleteViewModel DeleteViewModel { get; set; }
    }
}