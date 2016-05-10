namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class MediaThumbnail
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
    }
}