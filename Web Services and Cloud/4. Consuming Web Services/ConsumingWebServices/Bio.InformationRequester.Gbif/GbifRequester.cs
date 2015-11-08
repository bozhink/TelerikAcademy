namespace Bio.InformationRequester.Gbif
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class GbifRequester
    {
        public async Task<GbifResult> GetSpeciesInformation(string scientificName)
        {
            if (string.IsNullOrEmpty(scientificName.Trim()))
            {
                throw new ArgumentNullException("scientificName");
            }

            string requestName = Uri.EscapeDataString(Uri.UnescapeDataString(scientificName))
                .Replace("%20", "+");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.gbif.org");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resposeJsonString = await client.GetStringAsync($"v0.9/species/match?verbose=true&name={requestName}");

                var response = JsonConvert.DeserializeObject<GbifResult>(resposeJsonString);
                return response;
            }
        }
    }
}