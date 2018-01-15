using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models.Database
{
    public class Location
    {
        public int Id { get; set; }
        
        public int ApiId { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
