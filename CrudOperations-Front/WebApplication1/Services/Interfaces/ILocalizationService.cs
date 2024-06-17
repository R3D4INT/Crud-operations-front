using System.Reflection;
using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Services.Interfaces
{
    public interface ILocalizationService
    {
        TViewModel GetLocalizedViewModel<TViewModel>(string baseName, Assembly assembly)
            where TViewModel : ILocalizableViewModel, new();
    }
}
