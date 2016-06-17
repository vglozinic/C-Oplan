using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplan
{
    class Izvjestaji
    {
        static private promjena promjena = null;

        static public bool ProvjeriIzvjestaj(int id_korisnik)
        {
            using (var db = new EntitiesSettings())
            {
                promjena = (from p in db.promjena
                            where p.id_korisnik == id_korisnik
                            select p).FirstOrDefault<promjena>();
                if (promjena == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        static public void IzbrisiIzvjestaj(int id_korisnik)
        {
            using (var db = new EntitiesSettings())
            {
                var upit = from p in db.promjena
                           where p.id_korisnik == id_korisnik
                           select p;

                foreach (var promjena in upit)
                {
                    db.promjena.Remove(promjena);
                }
                db.SaveChanges();
            }
        }
    }
}
