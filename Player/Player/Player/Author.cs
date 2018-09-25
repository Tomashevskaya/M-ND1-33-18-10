using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Author
    {
        public string Name { get; set; }

        public Song[] Songs { get; set; }

        public Album[] Albums { get; set; }
    }
}
