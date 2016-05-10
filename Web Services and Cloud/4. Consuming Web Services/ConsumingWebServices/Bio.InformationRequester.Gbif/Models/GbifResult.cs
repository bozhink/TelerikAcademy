namespace Bio.InformationRequester.Gbif.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public class GbifResult
    {
        [JsonProperty(propertyName: "usageKey")]
        public int UsageKey { get; set; }

        [JsonProperty(propertyName: "scientificName")]
        public string ScientificName { get; set; }

        [JsonProperty(propertyName: "canonicalName")]
        public string CanonicalName { get; set; }

        [JsonProperty(propertyName: "rank")]
        public string Rank { get; set; }

        [JsonProperty(propertyName: "synonym")]
        public bool Synonym { get; set; }

        [JsonProperty(propertyName: "confidence")]
        public int Confidence { get; set; }

        [JsonProperty(propertyName: "note")]
        public string Note { get; set; }

        [JsonProperty(propertyName: "matchType")]
        public string MatchType { get; set; }

        [JsonProperty(propertyName: "alternatives")]
        public IEnumerable<Alternative> Alternatives { get; set; }

        [JsonProperty(propertyName: "kingdom")]
        public string Kingdom { get; set; }

        [JsonProperty(propertyName: "phylum")]
        public string Phylum { get; set; }

        [JsonProperty(propertyName: "order")]
        public string Order { get; set; }

        [JsonProperty(propertyName: "family")]
        public string Family { get; set; }

        [JsonProperty(propertyName: "genus")]
        public string Genus { get; set; }

        [JsonProperty(propertyName: "kingdomKey")]
        public int KingdomKey { get; set; }

        [JsonProperty(propertyName: "phylumKey")]
        public int PhylumKey { get; set; }

        [JsonProperty(propertyName: "classKey")]
        public int ClassKey { get; set; }

        [JsonProperty(propertyName: "orderKey")]
        public int OrderKey { get; set; }

        [JsonProperty(propertyName: "familyKey")]
        public int FamilyKey { get; set; }

        [JsonProperty(propertyName: "genusKey")]
        public int GenusKey { get; set; }

        [JsonProperty(propertyName: "class")]
        public string Class { get; set; }
    }
}