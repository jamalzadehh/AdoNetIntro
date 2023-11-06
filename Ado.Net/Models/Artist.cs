using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }

        internal void Add(List<Artist> artist)
        {
            throw new NotImplementedException();
        }
    }
}
