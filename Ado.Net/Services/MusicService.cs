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
    internal class MusicService
    {
        private Sql _database = new Sql();
        public void CreateMusic(Music music)
        {
            string cmd = $"Insert Into Values ({music.Id},'{music.Name}',{music.Duration},{music.CategoryId},{music.ArtistId})";
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
        public List<Music> GetMusicList()
        {
            string query = "Select * From Music";
            DataTable table = _database.ExecuteQuery(query);
            List<Music> musics = new List<Music>();
            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    Duration = (int)row["Duration"],
                    CategoryId = (int)row["Category"],
                    ArtistId = (int)row["ArtistId"]
                };
                musics.Add(music);
            }
            return musics;
        }
        public void DeleteMusic(int id)
        {
            string cmd = $"DELETE FROM Musics WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }

        public Music GetMusicById(int id)
        {
            string query = $"SELECT * FROM Musics WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);
            if (table.Rows.Count > 0)
            {
                Music music = new Music
                {
                    Id = (int)table.Rows[0]["Id"],
                    Name = table.Rows[0]["Name"].ToString(),
                    Duration = (int)table.Rows[0]["Duration"],
                    CategoryId = (int)table.Rows[0]["CategoryId"],
                    ArtistId = (int)table.Rows[0]["ArtistId"],
                };
                return music;
            }
            else
            {
                throw new Exception("Music not found.");
            }
        }
        internal List<Music> GetAllMusics()
        {
            throw new NotImplementedException();
        }
    }
}

