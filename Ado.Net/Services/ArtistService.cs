using Ado.Net.Data;
using Ado.Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.Services
{

    internal class ArtistService
    {
        private Sql _database = new Sql();
        private List<Artist> artists;

        public void CreateArtist(Artist artist)
        {
            string cmd = $"Insert Into Artist Values('{artist.Name}','{artist.Surname}','{artist.Gender}','{artist.Birthday}')";
            int result = _database.ExecuteCommand(cmd);
            if (result > 0)
            {
                Console.WriteLine("Command succesfully completed.");
            }
            else
            {
                Console.WriteLine("Error occured.");
            }

        }
        public List<Artist> GetAllArtists()
        {
            string query = "Select * From Artists";
            DataTable table = _database.ExecuteQuery(query);
            List<Artist> artists = new List<Artist>();
            foreach (DataRow row in table.Rows)
            {
                Artist artist = new Artist
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Birthday = DateTime.Parse(row["Birthday"].ToString()),
                    Gender = row["Gender"].ToString()
                };
                artists.Add(artist);
            }
            return artists;

        }
        public void DeleteArtist(int id)
        {
            string cmd = $"DELETE FROM Artists WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }

        public Artist GetArtistById(int id)
        {
            string query = $"SELECT * FROM Artists WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                Artist artist = new Artist
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[0]["Name"].ToString(),
                    Surname = table.Rows[0]["Surname"].ToString(),
                    Birthday = DateTime.Parse(table.Rows[0]["Birthday"].ToString()),
                    Gender = table.Rows[0]["Gender"].ToString(),
                };

                return artist;
            }
            else
            {
                throw new Exception("Artist tapilamdi.");
            }
        }
    }
}

        


