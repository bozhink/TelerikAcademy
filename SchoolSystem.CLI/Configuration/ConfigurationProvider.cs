namespace SchoolSystem.Cli.Configuration
{
    using System.Configuration;

    public class ConfigurationProvider : IConfigurationProvider
    {
        public bool IsTestEnvironment
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);
            }
        }
    }
}
