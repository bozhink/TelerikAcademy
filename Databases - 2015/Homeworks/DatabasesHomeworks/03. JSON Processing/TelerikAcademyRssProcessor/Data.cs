namespace TelerikAcademyRssProcessor
{
    using System.Net;
    using System.Text;

    public class Data
    {
        public void GetRssFeed(string url, string outputFileName)
        {
            WebClient client = new WebClient
            {
                Encoding = Encoding.UTF8
            };

            client.DownloadFile(url, outputFileName);
        }
    }
}
