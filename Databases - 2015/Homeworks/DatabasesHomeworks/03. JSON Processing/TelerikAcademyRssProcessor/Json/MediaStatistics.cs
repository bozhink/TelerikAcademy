namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class MediaStatistics
    {
        [JsonProperty("@views")]
        public string Views { get; set; }
    }
}