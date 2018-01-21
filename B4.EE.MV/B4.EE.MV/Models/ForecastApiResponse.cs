using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models
{
    public class ForecastApiResponse
    {
        /// <summary>
        /// List of forecasts
        /// </summary>
        [DeserializeAs(Name = "List")]
        public List<Forecast> Forecasts { get; set; }
        public City City { get; set; }
    }

    public class Forecast
    {
        [DeserializeAs(Name = "Dt")]
        public DateTime ForecastDateTime { get; set; }

        [DeserializeAs(Name = "Main")]
        public TemperatureInfo TemperatureInfo { get; set; }

        [DeserializeAs(Name = "Clouds")]
        public Clouds CloudInfo { get; set; }

        [DeserializeAs(Name = "Wind")]
        public Wind WindInfo { get; set; }
        public string Dt_txt { get; set; }

        [DeserializeAs(Name = "Weather")]
        public List<WeatherCondition> WeatherConditions { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        [DeserializeAs(Name = "Coord")]
        public Position Position { get; set; }
        [DeserializeAs(Name = "Country")]
        public string CountryCode { get; set; }
    }
}
