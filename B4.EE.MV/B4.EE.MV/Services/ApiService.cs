using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;
using B4.EE.MV.Models;

namespace B4.EE.MV.Services
{
    class ApiService
    {
        private const string API_KEY = "30d1c831738ed536e2e15616249e2570";
        private const string API_URL = "http://api.openweathermap.org";
        private RestClient client;

        public ApiService()
        {
            client = new RestClient(API_URL);
        }

        public WeatherApiResponse GetCityWeather(string city)
        {
            string json = string.Empty;
            var request = new RestRequest("data/2.5/weather",Method.GET);

            request.AddParameter("q", city);
            request.AddParameter("APPID", API_KEY);
            request.AddParameter("units", "metric");

            IRestResponse<WeatherApiResponse> response = client.Execute<WeatherApiResponse>(request);

            return response.Data;
        }
    }
}
