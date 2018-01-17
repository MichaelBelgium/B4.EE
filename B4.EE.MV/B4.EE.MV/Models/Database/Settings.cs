using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models.Database
{
    class Settings
    {
        public const string UNIT_METRIC = "metric";
        public const string UNIT_STANDARD = "standard";
        public const string UNIT_IMPERIAL = "imperial";

        public static Location SelectedLocation { get; set; }
        public static string Unit { get; set; }
    }
}
