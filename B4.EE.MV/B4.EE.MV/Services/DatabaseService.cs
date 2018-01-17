using B4.EE.MV.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace B4.EE.MV.Services
{
    class DatabaseService
    {
        private SQLiteConnection conn;

        public DatabaseService()
        {
            conn = new SQLiteConnection(
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "database.db"
            ));

            conn.CreateTable<Location>();

            if(conn.Table<Location>().Count() == 0)
                conn.Insert(new Location { ApiId = 2800931, Name = "Bruges", Selected = true });
            
            SetSelectedLocation(GetSelectedLocation());
        }

        public List<Location> GetLocations()
        {
            return conn.Table<Location>().ToList();
        }

        public Location GetSelectedLocation()
        {
            return conn.Table<Location>().First(l => l.Selected == true);
        }

        public void RemoveLocation(int id)
        {
            if (conn.Table<Location>().Count() == 1)
                throw new Exception("The app needs minimum 1 location.");

            conn.Delete<Location>(id);
        }

        public void RemoveLocation(Location location)
        {
            RemoveLocation(location.Id);
        }

        public void SetSelectedLocation(Location location)
        {
            var selected = GetSelectedLocation();
            selected.Selected = false;
            conn.Update(selected);

            var newSelected = conn.Table<Location>().First(l => l.ApiId == location.ApiId);
            newSelected.Selected = true;
            conn.Update(newSelected);

            Settings.SelectedLocation = location;
        }

        public void AddLocation(int id, string city)
        {
            conn.Insert(new Location { ApiId = id, Name = city });
        }
    }
}
