namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}