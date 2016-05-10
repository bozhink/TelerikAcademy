namespace TelerikAcademyRssProcessor.Json
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Feed
    {
        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("entry")]
        public List<Entry> Entry { get; set; }
    }
}