using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models.Database
{
    class Settings
    {
        public enum Units  { Metric, Standard, Imperial }
        public static Location SelectedLocation { get; set; }
        public static Units Unit { get; set; }
    }
}
