using System.Collections.Generic;
using WebApplication1.Models.Localization.Interfaces;
using WebApplication1.Models.Localization.User;

namespace WebApplication1.Models.Localization.CompositeViewsModels
{
    public class UserCompositeViewModel : ILocalizableViewModel
    {
        public IEnumerable<Models.User> Users { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}