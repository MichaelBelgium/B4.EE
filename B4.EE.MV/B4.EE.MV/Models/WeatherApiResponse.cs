using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace B4.EE.MV.Models
{
    public class WeatherApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Coord { get; set; }
        public Wind Wind { get; set; }
        public Details Sys { get; set; }
        public Clouds Clouds { get; set; }
        public List<Weather> Weather { get; set; }
        public DateTime Dt { get; set; }
        public Temperature Main { get; set; }
    }

    public class Position
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Wind
    {
        /// <summary>
        /// Wind speed
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// Wind direction (degrees)
        /// </summary>
        public double Deg { get; set; }
    }

    public class Details
    {
        public string Country { get; set; }
        public DateTime Sunrise { get; set; }
    }

    public class Clouds
    {
        /// <summary>
        /// Amount of clouds in percentage  
        /// </summary>
        public byte All { get; set; }
    }

    public class Weather
    {
        /// <summary>
        /// Group of weather parameters
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Weather icon id
        /// </summary>
        public string Icon { get; set; }

        public ImageSource ImageSource => ImageSource.FromUri(new Uri($"http://openweathermap.org/img/w/{Icon}.png"));
    }

    public class Temperature
    {
        public int Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Temp_min { get; set; }
        public int Temp_max { get; set; }
    }
}
