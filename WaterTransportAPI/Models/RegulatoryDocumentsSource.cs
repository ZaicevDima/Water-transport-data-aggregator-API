namespace WaterTransportAPI.Models
{
    public interface RegulatoryDocumentsSource
    {
        public abstract Task<List<string>> parse();
        //protected abstract Task<string> getContent(string url);
    }
}
