using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Yggdrasil
{
    public abstract class Request
    {
        public string Url { get; set; }
        public string ToPost { get; set; }
        public JObject Response { get; set; }

        public virtual Request DoPost()
        {
            byte[] body = Encoding.UTF8.GetBytes(ToPost);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream())) {
                streamWriter.Write(ToPost);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
            if (!string.IsNullOrWhiteSpace(response)) {
                Response = JObject.Parse(response);
            }
            return Parse(response);
        }

        public virtual Request Parse(string json)
        {
            return (Request) JsonConvert.DeserializeObject(json, GetType());
        }
    }
}
