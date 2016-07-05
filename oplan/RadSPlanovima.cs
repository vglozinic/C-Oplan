using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oplan
{
    class RadSPlanovima
    {
        /// <summary>
        /// Provjerava postoji li takav naziv plana u bazi podataka.
        /// </summary>
        /// <param name="naziv">Naziv plana koji se želi provjeriti</param>
        /// <returns>True ako naziv postoji, false ako ne postoji.</returns>
        static public bool ProvjeriPlan(string naziv)
        {
            using (var db = new EntitiesSettings())
            {
                var plan = (from p in db.plan
                            where p.naziv == naziv
                            select p).FirstOrDefault<plan>();
                if (plan == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Pronalazi plan i mijenja naziv za taj odabrani plan.
        /// </summary>
        /// <param name="stariNaziv">Naziv plana koji se mijenja</param>
        /// <param name="NoviNaziv">Novi naziv postojećeg plana</param>
        static public void PromjeniNaziv(string stariNaziv, string NoviNaziv)
        {
            using (var db = new EntitiesSettings())
            {
                var plan = (from p in db.plan
                            where p.naziv == stariNaziv
                            select p).FirstOrDefault<plan>();

                db.plan.Attach(plan);
                plan.naziv = NoviNaziv;
                db.SaveChanges();
            }
        }
    }
}
