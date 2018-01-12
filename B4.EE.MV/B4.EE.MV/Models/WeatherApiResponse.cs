using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models
{
    public class WeatherApiResponse
    {
        public string Name { get; set; }
        public Position Coord { get; set; }
    }

    public class Position
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }
}
