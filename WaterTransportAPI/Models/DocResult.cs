namespace WaterTransportAPI.Models
{
    public class DocResult
    {
        public List<DocElementResult> DocElements { get; set; } = new List<DocElementResult>();
    }

    public class DocElementResult
    {
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
