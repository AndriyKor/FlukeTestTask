namespace Fluke.Domain.Models.Options
{
    public class EONETConfiguration
    {
        public const string EONET = "EONET";
        
        public int MaxLimit { get; set; }
        public int MaxDays { get; set; }
        public UrlConfiguration Urls { get; set; }
    }

    public class UrlConfiguration
    {
        public string Events { get; set; }
        public string Categories { get; set; }
        public string Layers { get; set; }
    }
}
