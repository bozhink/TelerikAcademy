namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class MediaCommunity
    {
        [JsonProperty("media:statistics")]
        public MediaStatistics Statistics { get; set; }
    }
}