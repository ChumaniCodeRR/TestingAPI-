using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ApiTesting.Models;
using System.Threading.Tasks;
using System.IO;

namespace ApiTesting.Controllers
{
    public class ItemsController : ApiController
    {

        private static List<Item> _items = new List<Item>()
            {
                new Item() { Id = 1 , Name = "Name", Type = "Car"},
            };
        public ItemsController() { }
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
        [HttpGet]
        public Item GetItem(int id)
        {
            Item pro = _items.Find(p => p.Id == id);
            
            if (pro == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return pro;
            }
        }

        [Route("items/all")]
        [HttpGet]
        public IHttpActionResult ALL(string url)
        {
            url = "";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responseFrom = reader.ReadToEnd();
            reader.Close();
            return responseFrom;
        }


        [HttpGet]
        public static string HttpGet(string url)
        {
            url = "https://brollcrestest.brollonline.co.za/wcfPropData/IntegrationAPI.svc";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }

        [HttpGet]
        public static string HttpGetJson(string url, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWrite.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamRead = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamRead.ReadToEnd();
                return result;
            };
        }


        //public static string HttpGet(string url)
        //{
        //    string url = "";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await response.Content.ReadAsStringAsync();
        //            var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
        //        }
        //    }

        //    return "";
            
        //}
    }
}






        //IntegrationAPIClient client = new IntegrationAPIClient();

        //string BaseUrl  = "https://brollcrestest.brollonline.co.za/wcfPropData/IntegrationAPI.svc";

        //public async Task<ActionResult> Index()
        //{

        //}

        //private void Populate()
        //{

        //}
        //public class Item
        //{
        //    private const string url = "https://brollcrestest.brollonline.co.za/wcfPropData/IntegrationAPI.svc";
        //    private string UrlParameters = "?AccessKey=ebe6f46e-d1fb-4754-8eed-3d64e37def98&AuditUser=Chumani &BOLUserID=gchangfoot";

        //    public void Populate()
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(url);

        //        client.DefaultRequestHeaders.Accept.Add(
        //          new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = client.GetAsync(UrlParameters).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var dataObject = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;

        //            foreach (var d in dataObject)
        //            {
        //                Console.WriteLine("{0}", d.Name);
        //            }
        //        }
        //    }

        //private class IntegrationAPIClient
        //{

        //}


