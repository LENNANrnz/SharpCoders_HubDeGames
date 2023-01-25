using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubGameplay.Models
{
    public class Playersids
    {
        public int id1 { get; set; }
        public int id2 { get; set; }

        public Playersids() { }
        public Playersids(int id1, int id2)
        {
            this.id1 = id1;
            this.id2 = id2;
        }

       
    }
}
