namespace TelerikAcademyRssProcessor.Json
{
    using Newtonsoft.Json;

    public class Link
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}