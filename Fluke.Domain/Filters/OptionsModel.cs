namespace Fluke.Domain.Filters
{
    public class OptionsModel
    {
        public int? Limit { get; set; }
        public int? Days { get; set; }
        public string? Status { get; set; }
        public string? OrderBy { get; set; }
    }
}
