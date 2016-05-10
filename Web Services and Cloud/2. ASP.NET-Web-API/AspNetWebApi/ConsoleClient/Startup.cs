namespace ConsoleClient
{
    using System;

    public class Startup
    {
        public const string UrlPrefix = "http://localhost:47310/api";

        public static void Main(string[] args)
        {
            var random = RandomGenerator.RandomGenerator.Instance;

            {
                var userManager = new UserManager();

                var userRegistration = userManager.RegisterNewUser(
                    $"{UrlPrefix}/Account/Register",
                    $"{random.GetRandomString(10)}@xyz.com",
                    "Password123##").Result;

                Console.WriteLine(userRegistration.IsSuccessStatusCode);
            }

            {
                var countryManager = new CountryManager();

                var countryRegistration = countryManager.RegisterNewCountry(
                    $"{UrlPrefix}/Countries",
                    random.GetRandomString(6)).Result;

                Console.WriteLine(countryRegistration.IsSuccessStatusCode);

                var countries = countryManager.GetCountries($"{UrlPrefix}/Countries").Result;
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }
    }
}
