using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototip_OPPlan;

namespace oplan
{
    class RadSPlanovima
    {
        ///<summary>
        ///Provjerava postoji li takav naziv plana u bazi podataka.
        ///</summary>
        ///<returns>True ako naziv postoji, false ako ne postoji.</returns>
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

        static public void PromijeniNaziv(string stariNaziv, string NoviNaziv)
        {
            using (var db = new EntitiesSettings())
            {
                var plan = (from p in db.plan
                            where p.naziv == stariNaziv
                            select p).FirstOrDefault<plan>();

                plan.naziv = NoviNaziv;
                db.SaveChanges();
            }
        }

        static public void SpremiPlan(int prijavljeniKorisnik, string nazivPlana, List<podaci> markeri, List<rute> rute)
        {
            using(var db = new EntitiesSettings())
            {
                plan noviPlan = new plan();
                noviPlan.naziv = nazivPlana;
                noviPlan.datum = DateTime.Now;
                db.plan.Add(noviPlan);
                db.SaveChanges();

                int id = (from p in db.plan
                            orderby p.id_plan descending
                            select p.id_plan).FirstOrDefault();

                promjena novaPromjena = new promjena();
                novaPromjena.id_korisnik = prijavljeniKorisnik;
                novaPromjena.id_plan = id;
                novaPromjena.datum = DateTime.Now;
                novaPromjena.radnja = Promjene.spremioPlan;
                db.promjena.Add(novaPromjena);
                db.SaveChanges();


            }
        }
    }
}
