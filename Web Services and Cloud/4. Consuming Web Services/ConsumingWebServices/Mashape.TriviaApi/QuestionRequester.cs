namespace Mashape.TriviaApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class QuestionRequester
    {
        // Paste here your api key
        private const string ApiKey = "";

        public async Task<IEnumerable<TriviaResponse>> Get(int pageNumber, int itemsPerPage)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Mashape-Key", ApiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("https://pareshchouhan-trivia-v1.p.mashape.com");
                var responseJson = await client.GetStringAsync($"v1/getAllQuizQuestions?limit={itemsPerPage}&page={pageNumber}");

                var response = JsonConvert.DeserializeObject<IEnumerable<TriviaResponse>>(responseJson);

                return response;
            }
        }
    }
}