namespace ConsoleClient
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var userManager = new UserManager();

            var registration = userManager.RegisterNewUser("http://localhost:47310/api/Account/Register", "abc@xyz.com", "Password123##").Result;

            Console.WriteLine(registration.IsSuccessStatusCode);
        }
    }
}
