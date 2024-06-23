using WebApplication1.Models.Localization.Interfaces;

namespace WebApplication1.Models.Localization
{
    public class IndexViewModel : ILocalizableViewModel
    { 
        public string Title { get; set; }
        public string IndexTitle { get; set; }
        public string IndexWelcome { get; set; }
        public string IndexLearnMore { get; set; }
        public string IndexFirstSectionTitle { get; set; }
        public string IndexFirstSectionMessage { get; set; }
        public string IndexSecondSectionTitle { get; set; }
        public string IndexSecondSectionMessage { get; set; }
        public string IndexThirdSectionTitle { get; set; }
        public string IndexThirdSectionMessage { get; set; }
    }
}