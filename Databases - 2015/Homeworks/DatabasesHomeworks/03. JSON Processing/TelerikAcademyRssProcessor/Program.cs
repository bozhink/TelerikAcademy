namespace TelerikAcademyRssProcessor
{
    using System;
    using System.IO;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.GetRssFeed(Addresses.TelerikAcademyYoutubeRssFeedAddress, Addresses.RssOutputFileName);

            JsonController jsonController = new JsonController();

            var json = jsonController.ConvertXmlToJObject(Addresses.RssOutputFileName);
            var titles = jsonController.GetVideoTitles(json);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            string jsonString = jsonController.ConvertXmlToJson(Addresses.RssOutputFileName);
            var videos = jsonController.DeserializeJsonToVideos(jsonString);

            const string VideoDivTemplate = @"<div style=""display:inline-block;"">
<iframe width=""420"" height=""315"" src=""https://www.youtube.com/embed/{0}""></iframe><br />
<a href=""{1}"" target=""_blank"">{3}</a></div>";

            StringBuilder htmlContent = new StringBuilder();
            foreach (var video in videos)
            {
                htmlContent.Append(string.Format(VideoDivTemplate, video.Link.Substring("http://www.youtube.com/watch?v=".Length), video.Link, video.Img, video.Title, video.Views, video.PublishedDate));
            }

            const string HtmlTemplate = @"<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
    <title>Video</title>
</head>
<body>
{0}
</body>
</html>";

            string html = string.Format(HtmlTemplate, htmlContent.ToString());

            using (StreamWriter writer = new StreamWriter(Addresses.OutputHtmlFile))
            {
                writer.Write(html);
            }
        }
    }
}
