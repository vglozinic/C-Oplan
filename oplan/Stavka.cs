using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplan
{
    class Stavka
    {
        public int id_postrojbe { get; set; }
        public string tekst { get; set; }

        public Stavka(int id, string naziv)
        {
            this.id_postrojbe = id;
            this.tekst = naziv;
        }
    }
}
