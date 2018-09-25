using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Domain
{
    public class Artist
    {
        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public Album[] Albums { get; set; }
    }
}
