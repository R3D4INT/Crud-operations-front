using WebApplication1.Models.enums;

namespace WebApplication1.Models
{
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Region Region { get; set; }
    }
}