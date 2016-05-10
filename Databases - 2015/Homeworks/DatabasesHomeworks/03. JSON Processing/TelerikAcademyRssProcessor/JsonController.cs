namespace TelerikAcademyRssProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Json;

    public class JsonController
    {
        public string ConvertXmlToJson(string xmlFilePath)
        {
            XmlDocument xml = GetXmlDocument(xmlFilePath);
            string json = JsonConvert.SerializeXmlNode(xml);
            return json;
        }

        public JObject ConvertXmlToJObject(string xmlFilePath)
        {
            JObject result = JObject.Parse(ConvertXmlToJson(xmlFilePath));
            return result;
        }

        public IEnumerable<JToken> GetVideoTitles(JObject json)
        {
            var result = json["feed"]["entry"].Select(entry => entry["title"]);
            return result;
        }

        public IEnumerable<Video> DeserializeJsonToVideos(string json)
        {
            var deserializedVideos = JsonConvert.DeserializeObject<TelerikAcademyVideos>(json);
            var videos = deserializedVideos.Feed.Entry.Select(entry =>
            {
                return new Video
                {
                    Title = entry.Title,
                    Link = entry.Link.Href,
                    PublishedDate = DateTime.Parse(entry.Published),
                    Description = entry.Group.Description,
                    Views = int.Parse(entry.Group.Community.Statistics.Views),
                    Img = entry.Group.МediaТhumbnail.Url
                };
            });

            return new HashSet<Video>(videos);
        }

        private XmlDocument GetXmlDocument(string xmlfilePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.PreserveWhitespace = true;
            try
            {
                xml.Load(xmlfilePath);
            }
            catch
            {
                throw;
            }

            return xml;
        }
    }
}
