using AutoMapper;
using System.Globalization;
using System.Reflection;
using System.Resources;
using WebApplication1.App_Start;
using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Services
{
    public class LocalizationService
    {
        private readonly CultureInfo _culture;

        public LocalizationService(CultureInfo culture)
        {
            _culture = culture;
        }

        public TViewModel GetLocalizedViewModel<TViewModel>(string baseName, Assembly assembly) where TViewModel : ILocalizableViewModel, new()
        {
            var resourceManager = new ResourceManager(baseName, assembly);
            var resourceSet = resourceManager.GetResourceSet(_culture, true, true);

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = new Mapper(config);

            return mapper.Map<TViewModel>(resourceSet);
        }
    }
}