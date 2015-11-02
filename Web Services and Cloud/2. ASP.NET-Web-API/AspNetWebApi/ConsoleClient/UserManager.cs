namespace ConsoleClient
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public class UserManager
    {
        private const string DefaultContentType = "application/json";
        private readonly Encoding defaultEncoding = Encoding.UTF8;

        public async Task<HttpResponseMessage> RegisterNewUser(string apiUrl, string email, string password)
        {
            var user = new UserRegistration
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };

            string userJson = JsonConvert.SerializeObject(user);

            using (var client = new HttpClient())
            {
                var content = new StringContent(userJson, this.defaultEncoding, UserManager.DefaultContentType);
                return await client.PostAsync(apiUrl, content);
            }
        }
    }
}
