namespace ConsoleClient
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class CountryManager
    {
        private const string DefaultContentType = "application/json";
        private readonly Encoding defaultEncoding = Encoding.UTF8;

        public async Task<HttpResponseMessage> RegisterNewCountry(string apiUrl, string name)
        {
            var country = new CountryRegistration
            {
                Name = name
            };

            string countryJson = JsonConvert.SerializeObject(country);

            using (var client = new HttpClient())
            {
                var content = new StringContent(countryJson, this.defaultEncoding, CountryManager.DefaultContentType);
                return await client.PostAsync(apiUrl, content);
            }
        }

        public async Task<IEnumerable<CountryRegistration>> GetCountries(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync(apiUrl);

                return JsonConvert.DeserializeObject<IEnumerable<CountryRegistration>>(jsonString);
            }
        }
    }
}
