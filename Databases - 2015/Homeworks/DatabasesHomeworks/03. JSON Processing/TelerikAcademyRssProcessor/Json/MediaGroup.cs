namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class MediaGroup
    {
        [JsonProperty("media:description")]
        public string Description { get; set; }

        [JsonProperty("media:thumbnail")]
        public MediaThumbnail МediaТhumbnail { get; set; }

        [JsonProperty("media:community")]
        public MediaCommunity Community { get; set; }
    }
}