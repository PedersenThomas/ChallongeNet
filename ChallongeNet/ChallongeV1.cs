using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace ChallongeNet
{
    /// <summary>
    /// Challonge V1 library.
    /// </summary>
    public partial class ChallongeV1
    {
        #region CoreCommunication
        private const string BaseUrl = "https://api.challonge.com/v1/";

        private readonly NetworkCredential credential;

        public ChallongeV1(string username, string apiKey)
        {
            this.Username = username;
            this.Apikey = apiKey;
            this.credential = new NetworkCredential(this.Username, this.Apikey);
        }

        public string Username { get; private set; }

        public string Apikey { get; private set; }

        /// <summary>
        /// Makes a request where the payload of POST, PUT and DELETE requests are formatted as JSON.
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="httpMethode"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private string MakeJsonRequest(string apiUrl, string httpMethode, Dictionary<string, dynamic> dictionary = null)
        {
            const string ResponseType = "json";
            var url = string.Format("{0}{1}.{2}", BaseUrl, apiUrl, ResponseType);
            var encoding = new ASCIIEncoding();

            if (httpMethode == WebRequestMethods.Http.Get)
            {
                if (dictionary != null && dictionary.Count > 0)
                {
                    url += "?" + this.DictionaryQuerystring(dictionary);
                }
            }

            Debug.WriteLine("{0} Url:{1}", httpMethode, url);
            var request = WebRequest.Create(url);
            request.Proxy = null;
            request.Credentials = this.credential;
            request.ContentType = "application/json";
            request.Method = httpMethode;

            switch (httpMethode)
            {
                case WebRequestMethods.Http.Post:
                case "DELETE":
                case WebRequestMethods.Http.Put:
                    if (dictionary != null && dictionary.Count > 0)
                    {
                        string json = JsonConvert.SerializeObject(dictionary);
                        Debug.WriteLine("Payload: " + json);
                        var data = encoding.GetBytes(json);
                        request.ContentLength = data.Length;

                        Debug.WriteLineIf(data.Length == 0, "There is no parameters to send. Url: " + url);
                        if (data.Length > 0)
                        {
                            Stream streamOut = request.GetRequestStream();
                            streamOut.Write(data, 0, data.Length);
                        }
                    }

                    break;

                case WebRequestMethods.Http.Get:
                    break;

                default:
                    throw new ChallongeException("Unknown httpMethode: " + httpMethode);
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
                    {
                        var stream = new StreamReader(response.GetResponseStream());
                        string reponseText = stream.ReadToEnd();
                        Debug.WriteLine(reponseText);
                        return reponseText;
                    }
                    else
                    {
                        string message = String.Format(
                            "{0} {1}",
                            ((HttpWebResponse)response).StatusCode,
                            ((HttpWebResponse)response).StatusDescription);
                        Debug.WriteLine(string.Format("ChallongeException: {0}", message));
                        throw new ChallongeException(message);
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    var stream = new StreamReader(e.Response.GetResponseStream());

                    string message = String.Format("{0} {1}", e.Message, stream.ReadToEnd());
                    Debug.WriteLine(string.Format("ChallongeException: {0}", message));
                    throw new ChallongeException(message, e);
                }
                else
                {
                    throw new ChallongeException("The request didn't have data.", e);
                }
            }
        }
        #endregion

        private string DictionaryQuerystring(Dictionary<string, dynamic> dict)
        {
            var queryList = new List<string>();

            foreach (KeyValuePair<string, dynamic> pair in dict)
            {
                queryList.Add(string.Format("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value.ToString())));
            }

            return String.Join("&", queryList);
        }
    }

    public class ChallongeException : Exception
    {
        public ChallongeException()
        {
        }

        public ChallongeException(string message)
            : base(message)
        {
        }

        public ChallongeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
