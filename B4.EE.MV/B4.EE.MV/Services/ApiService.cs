using B4.EE.MV.Models;
using Plugin.Geolocator;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

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

        public async Task<WeatherApiResponse> GetCityWeather(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.GET);

            request.AddParameter("q", city);
            request.AddParameter("APPID", API_KEY);
            request.AddParameter("units", "metric");
            request.AddParameter("lang", "nl");

            IRestResponse<WeatherApiResponse> response = await client.ExecuteTaskAsync<WeatherApiResponse>(request);
                
            return response.StatusCode == HttpStatusCode.OK ? response.Data : null;
        }

        public async Task<WeatherApiResponse> GetCityWeatherGps()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
            {
                return null;
            }

            try
            {
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1000), null, true);

                return await GetCityWeather(position.Longitude, position.Latitude);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        private async Task<WeatherApiResponse> GetCityWeather(double longitude, double latitude)
        {
            var request = new RestRequest("data/2.5/weather", Method.GET);

            request.AddParameter("APPID", API_KEY);
            request.AddParameter("units", "metric");
            request.AddParameter("lang", "nl");
            request.AddParameter("lon", longitude);
            request.AddParameter("lat", latitude);

            IRestResponse<WeatherApiResponse> response = await client.ExecuteTaskAsync<WeatherApiResponse>(request);

            return response.StatusCode == HttpStatusCode.OK ? response.Data : null;
        }
    }
}
