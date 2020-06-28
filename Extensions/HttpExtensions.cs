using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;

namespace ducky_api_server.Extensions
{
    public class HttpExtensions
    {

    }
    public enum HttpContentType
    {
        [Description("application/json")]
        Json,
        [Description("application/x-www-form-urlencoded")]
        Form,
    }
    public class Http
    {
        public string Uri { get; set; } = "";
        public string Method { get; set; } = "";
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// json格式字符串
        /// </summary>
        /// <value></value>
        public string Body { get; set; } = "";
        public int Timeout { get; set; } = 15000;
        public HttpContentType ContentType { get; set; } = HttpContentType.Json;
        public Http(string uri)
        {
            Uri = uri;
        }

        public string BeginRequest()
        {
            if (Method.IsEmpty())
            {
                throw new ArgumentNullException("method cannot be null or empty");
            }
            return GetResponse();
        }
        public string Get(Dictionary<string, string> parameters = null, Dictionary<string, string> headers = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();
            Headers = headers ?? new Dictionary<string, string>();
            Method = "GET";

            return GetResponse();
        }
        public string Post(object data = null, Dictionary<string, string> headers = null)
        {
            Body = (data ?? new { }).ToJson();
            Headers = headers ?? new Dictionary<string, string>();
            Method = "POST";

            return GetResponse();
        }
        public string Put(object data = null, Dictionary<string, string> headers = null)
        {
            Body = (data ?? new { }).ToJson();
            Headers = headers ?? new Dictionary<string, string>();
            Method = "PUT";

            return GetResponse();
        }
        public string Delete(object data = null, Dictionary<string, string> headers = null)
        {
            Body = (data ?? new { }).ToJson();
            Headers = headers ?? new Dictionary<string, string>();
            Method = "DELETE";

            return GetResponse();
        }

        private string GetResponse()
        {
            var request = WebRequest.Create(Uri);
            request.Method = Method;
            request.Timeout = Timeout;
            request.Headers.Add("User-Agent", "ducky-api-server/v1");
            foreach (var item in Headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }
            if (Method.ToUpper() != "GET")
            {
                string body = GenerateParmeters();
                byte[] buffer = Encoding.UTF8.GetBytes(body);

                request.ContentType = ContentType.GetDescription();
                request.ContentLength = buffer.Length;
                var stream = request.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();
            }
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(resStream, Encoding.GetEncoding("utf-8"));
            string responseContent = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            resStream.Close();

            return responseContent;
        }

        private string GenerateFullUrl()
        {
            string fullUrl = Uri.TrimEnd('?');
            if (Method.ToUpper() == "GET")
            {
                fullUrl += "?" + GenerateParmeters();
            }
            return fullUrl;
        }
        private string GenerateParmeters()
        {
            string parameters = "";
            if (Method.ToUpper() == "GET")
            {
                List<string> list = new List<string>();
                foreach (var item in Parameters)
                {
                    list.Add($"{item.Key}={item.Value}");
                }
                parameters = string.Join("&", list);
            }
            else
            {
                switch (ContentType)
                {
                    case HttpContentType.Json:
                        parameters = Body;
                        break;
                    case HttpContentType.Form:
                        {
                            List<string> list = new List<string>();
                            foreach (var item in Parameters)
                            {
                                list.Add($"{item.Key}={item.Value}");
                            }
                            parameters = string.Join("&", list);
                        }
                        break;
                }
            }
            return parameters;
        }
    }
}