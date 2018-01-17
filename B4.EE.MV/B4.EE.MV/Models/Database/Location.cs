using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.MV.Models.Database
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int ApiId { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public bool Selected { get; set; }
    }
}
