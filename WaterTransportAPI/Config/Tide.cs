namespace WaterTransportAPI.Config
{
    public class Tide
    {
        private string tideType { get; set; } = string.Empty;
        private string time { get; set; } = string.Empty;
        private string waterLevel { get; set; } = string.Empty;

        Tide(string tideType, string time, string waterLevel)
        {
            this.tideType = tideType;
            this.time = time;
            this.waterLevel = waterLevel;
        }
    }
}
