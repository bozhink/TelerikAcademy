namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class Entry
    {
        [JsonProperty("media:group")]
        public MediaGroup Group { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}