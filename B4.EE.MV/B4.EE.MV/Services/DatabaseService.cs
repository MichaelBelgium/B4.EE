using B4.EE.MV.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace B4.EE.MV.Services
{
    class DatabaseService
    {
        private List<Location> locations;

        public DatabaseService()
        {
            locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    ApiId = 2800931,
                    Name = "Bruges",
                    Selected = true
                }
            };
        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public void AddLocation(int id, string city)
        {
            locations.Add(new Location { ApiId = id, Name = city, Id = locations.Max(l => l.Id) + 1 });
        }
    }
}
