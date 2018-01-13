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
        public List<Forecast> List { get; set; }
        public City City { get; set; }
    }

    public class Forecast
    {
        public DateTime Dt { get; set; }
        public Temperature Main { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public string Dt_txt { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public Position Coord { get; set; }
        public string Country { get; set; }
    }
}
