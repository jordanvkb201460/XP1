using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XP
{
    public class RestService
    {
        public static HttpClient client;
        public static Dictionary<string, string> dic;

        public RestService()
        {
        }

        public static async Task<List<T>> Request<T>(Dictionary<string, string> dic, string page)
        {

            try
            {
                if (client == null) client = new HttpClient();
                Dictionary<string, string> values = dic;
                FormUrlEncodedContent content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/test", content).ConfigureAwait(false);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(responseString);
            }
            catch (Exception e)
            {

                throw new HttpRequestException("Erreur de connexion : " + e.Message.ToString());
            }

        }

        public static T Request<T>()
        {
            const string URL = "https://www.xpmobile.ovh/getExperiences";

            using (var webClient = new WebClient())
            {
                try
                {
                    string json = webClient.DownloadString(URL);

                    var test = JsonConvert.DeserializeObject<T>(json);
                    int debug = 10;
                    return test;
                }
                catch(Exception e)
                {
                    Debug.Write(e.Message);
                    //return e.Message;
                    return default(T);
                }
               
            }
               
        }


        public static T PostRequest<T>(Object item, string url)
        {
            string URL = "https://www.xpmobile.ovh/"+url;
            T oui = default(T);
            using (WebClient client = new WebClient())
            {
                try
                {
                   var json = JsonConvert.SerializeObject(item);
                   string json2 = client.UploadString(URL, json);
                   oui = JsonConvert.DeserializeObject<T>(json2); 
                }
                catch(Exception e)
                {
                   return oui;
                }
                return oui;
            }
        }


        public static async void Request(Dictionary<string, string> dic, string page)
        {

            try
            {
                if (client == null) client = new HttpClient();
                Dictionary<string, string> values = dic;
                FormUrlEncodedContent content = new FormUrlEncodedContent(values);
                await client.PostAsync("http://127.0.0.1:8000/" + page + ".php", content).ConfigureAwait(false);
            }
            catch (Exception e)
            {

                throw new HttpRequestException("Erreur de connexion : " + e.Message.ToString());
            }

        }
    }
}
