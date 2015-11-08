namespace Mashape.TriviaApi.Models
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class TriviaResponse
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }

        [JsonProperty(propertyName: "q_category_id")]
        public int CategoryId { get; set; }

        [JsonProperty(propertyName: "q_text")]
        public string Text { get; set; }

        [JsonProperty(propertyName: "q_options_1")]
        public string Options1 { get; set; }

        [JsonProperty(propertyName: "q_options_2")]
        public string Options2 { get; set; }

        [JsonProperty(propertyName: "q_options_3")]
        public string Options3 { get; set; }

        [JsonProperty(propertyName: "q_options_4")]
        public string Options4 { get; set; }

        [JsonProperty(propertyName: "q_correct_option")]
        public int CorrectOption { get; set; }

        [JsonProperty(propertyName: "q_difficulty_level")]
        public int DifficultyLevel { get; set; }

        [JsonProperty(propertyName: "q_date_added")]
        public DateTime DateAdded { get; set; }
    }
}