namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class TelerikAcademyVideos
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }
    }
}