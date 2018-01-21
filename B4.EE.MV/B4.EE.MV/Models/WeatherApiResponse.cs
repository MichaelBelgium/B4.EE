using B4.EE.MV.Models.Database;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace B4.EE.MV.Models
{
    public class WeatherApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DeserializeAs(Name = "Coord")]
        public Position Position { get; set; }

        [DeserializeAs(Name = "Wind")]
        public Wind WindInfo { get; set; }

        [DeserializeAs(Name = "Sys")]
        public Details OtherInfo { get; set; }

        [DeserializeAs(Name = "Clouds")]
        public Clouds CloudInfo { get; set; }

        [DeserializeAs(Name = "Weather")]
        public List<WeatherCondition> WeatherConditions { get; set; }

        [DeserializeAs(Name = "Dt")]
        public DateTime UpdatedAt { get; set; }

        [DeserializeAs(Name = "Main")]
        public TemperatureInfo TemperatureInfo { get; set; }
    }

    public class Position
    {
        [DeserializeAs(Name = "Lon")]
        public float Longitude { get; set; }
        [DeserializeAs(Name = "Lat")]
        public float Latitude { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }

        [DeserializeAs(Name = "Deg")]
        public double Direction { get; set; }
    }

    public class Details
    {
        [DeserializeAs(Name = "Country")]
        public string CountryCode { get; set; }
        [DeserializeAs(Name = "Sunrise")]
        public DateTime SunriseAt { get; set; }
    }

    public class Clouds
    {
        [DeserializeAs(Name = "All")]
        public byte Percentage { get; set; }
    }

    public class WeatherCondition
    {
        /// <summary>
        /// Group of weather parameters
        /// </summary>
        [DeserializeAs(Name = "Main")]
        public string ConditionGroup { get; set; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        [DeserializeAs(Name = "Description")]
        public string ConditionDescription { get; set; }
        /// <summary>
        /// Weather icon id
        /// </summary>
        public string Icon { get; set; }

        public ImageSource ImageSource => ImageSource.FromUri(new Uri($"http://openweathermap.org/img/w/{Icon}.png"));
    }

    public class TemperatureInfo
    {
        [DeserializeAs(Name = "Temp")]
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        [DeserializeAs(Name = "Temp_min")]
        public int MinTemperature { get; set; }

        [DeserializeAs(Name = "Temp_max")]
        public int MaxTemperature { get; set; }

        public string TempString
        {
            get
            {
                string unit = string.Empty;
                switch(Settings.Unit)
                {
                    case Settings.UNIT_METRIC: return $"{Temperature} °C";
                    case Settings.UNIT_IMPERIAL: return $"{Temperature} °F";
                    default: return $"{Temperature} K";
                }
            }
        }
    }
}
