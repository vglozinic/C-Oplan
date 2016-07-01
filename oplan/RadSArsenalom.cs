using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oplan
{
    class RadSArsenalom
    {
        public static void PopuniPostrojbama(System.Windows.Forms.ComboBox nazivKontrole)
        {
            using (var db = new EntitiesSettings())
            {
                List<Stavka> listaStavki = new List<Stavka>();
                var prikazaniTekst = (from p in db.postrojba
                                      join v in db.vrsta on p.id_vrsta equals v.id_vrsta
                                      join t in db.tip_postrojbe on p.id_tip equals t.id_tip
                                      select new
                                      {
                                          id_postrojbe = p.id_postrojba,
                                          tekst = v.naziv + " - " + t.naziv
                                      }).ToList();


                foreach (var item in prikazaniTekst)
                {
                    listaStavki.Add(new Stavka(item.id_postrojbe, item.tekst));
                }

                nazivKontrole.DataSource = listaStavki;
                nazivKontrole.ValueMember = "id_postrojbe";
                nazivKontrole.DisplayMember = "tekst";
            }
        }

        public static void PopuniOpremom(System.Windows.Forms.ComboBox nazivKontrole)
        {
            using (var db = new EntitiesSettings())
            {
                nazivKontrole.DataSource = db.oprema.ToList();
                nazivKontrole.DisplayMember = "model";
                nazivKontrole.ValueMember = "id_oprema";
            }
        }

        public static bool DodajArsenal(int id_postrojbe, int id_opreme)
        {
            using (var db = new EntitiesSettings())
            {
                oprema p = new oprema
                {
                    id_oprema = id_opreme
                };

                db.oprema.Add(p);
                db.oprema.Attach(p);

                postrojba s = new postrojba
                {
                    id_postrojba = id_postrojbe
                };

                db.postrojba.Add(s);
                db.postrojba.Attach(s);

                p.postrojba.Add(s);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException iznimka)
                {
                    MessageBox.Show("Takva dodjela već postoji u bazi podataka!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static void IzmjeniArsenal(int SIDP, int SIDO, int NIDP, int NIDO)
        {
            ObrisiArsenal(SIDP, SIDO);
            if(DodajArsenal(NIDP, NIDO))
            {
                MessageBox.Show("Uspješno ste izmijenili arsenal.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DodajArsenal(SIDP, SIDO);
            }
        }

        public static void PrikaziPodatke(int filter, DataGridView dgvArsenal, System.Windows.Forms.ComboBox nazivKontrole)
        {
            if (filter == 1)
            {
                var itemPostrojba = nazivKontrole.SelectedItem as Stavka;
                if (itemPostrojba != null)
                {
                    PrikaziPoPostrojbama(dgvArsenal, itemPostrojba.id_postrojbe);
                }
            }
            else
            {
                var itemOprema = nazivKontrole.SelectedItem as oprema;
                if (itemOprema != null)
                {
                    PrikaziPoOpremi(dgvArsenal, itemOprema.id_oprema);
                }
            }
        }

        static public void PrikaziPoPostrojbama(DataGridView dgvArsenal, int id_postrojba)
        {
            using (var db = new EntitiesSettings())
            {
                var upit = (from p in db.postrojba
                            from o in p.oprema
                            join s in db.oprema on o.id_oprema equals s.id_oprema
                            join v in db.vrsta on p.id_vrsta equals v.id_vrsta
                            join t in db.tip_postrojbe on p.id_tip equals t.id_tip
                            join z in db.zemlja on s.id_zemlja equals z.id_zemlja
                            join m in db.tip_opreme on s.id_tip_oprema equals m.id_tip_oprema
                            where p.id_postrojba == id_postrojba
                            select new
                            {
                                IDP = p.id_postrojba,
                                IDO = s.id_oprema,
                                Model = s.model,
                                Tip = m.naziv,
                                Zemlja = z.naziv,
                                Opis = s.opis
                            }).ToList();


                dgvArsenal.DataSource = upit.ToList();

                dgvArsenal.Columns[0].Visible = false;
                dgvArsenal.Columns[1].Visible = false;
                dgvArsenal.Columns[5].Visible = false;

                dgvArsenal.Columns[2].Width = 234;
                dgvArsenal.Columns[3].Width = 180;
                dgvArsenal.Columns[4].Width = 120;
            }
        }

        static public void PrikaziPoOpremi(DataGridView dgvArsenal, int id_oprema)
        {
            using (var db = new EntitiesSettings())
            {
                var upit = (from p in db.oprema
                            from o in p.postrojba
                            join s in db.postrojba on o.id_postrojba equals s.id_postrojba
                            join v in db.vrsta on s.id_vrsta equals v.id_vrsta
                            join t in db.tip_postrojbe on s.id_tip equals t.id_tip
                            where p.id_oprema == id_oprema
                            select new
                            {
                                IDP = s.id_postrojba,
                                IDO = p.id_oprema,
                                Postrojba = v.naziv + " - " + t.naziv,
                                Oznaka = v.oznaka
                            }).ToList();

                dgvArsenal.DataSource = upit.ToList();

                dgvArsenal.Columns[0].Visible = false;
                dgvArsenal.Columns[1].Visible = false;

                dgvArsenal.Columns[2].Width = 434;
            }
        }

        static public void ObrisiArsenal(int id_postrojbe, int id_opreme)
        {
            using (var db = new EntitiesSettings())
            {
                var postrojba = db.postrojba.FirstOrDefault(p => p.id_postrojba == id_postrojbe);
                var oprema = db.oprema.FirstOrDefault(s => s.id_oprema == id_opreme);

                postrojba.oprema.Remove(oprema);
                db.SaveChanges();
            }
        }
    }
}
