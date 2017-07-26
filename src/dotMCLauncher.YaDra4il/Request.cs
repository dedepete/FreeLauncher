namespace dotMCLauncher.YaDra4il
{
    public abstract class Request
    {
        public string Url { get; set; }
        public string ToPost { get; set; }

        public virtual Request DoPost()
        {
            var body = System.Text.Encoding.UTF8.GetBytes(ToPost);
            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;
            using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(ToPost);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return Parse(new System.IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd());
        }

        public virtual Request Parse(string json)
        {
            return (Request)Newtonsoft.Json.JsonConvert.DeserializeObject(json, GetType());
        }
    }
}
