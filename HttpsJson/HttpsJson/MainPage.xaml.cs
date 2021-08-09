using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HttpsJson
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "Dette er en title";
            ApiUrl = RestServiceAsync();            
        }
        public async Task<ApiService> RestServiceAsync()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("https://api.thecatapi.com/v1/images/search");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("This is the result: " + result);
            var resultJson = JsonConvert.DeserializeObject<ApiService>(result); //var resultJson = result.Content.ReadAsStringAsync(); //JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync());
            Console.WriteLine("This is resultJson: " + resultJson);
            string url = resultJson.Url;

            Console.WriteLine("This is the url requested: " + url);

            return resultJson;
        }
        public string CustomConvert(Task task)
        {

        }
        public class ApiService
        {
            

            [JsonProperty("breeds")]

            public string Breeds { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }


        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
