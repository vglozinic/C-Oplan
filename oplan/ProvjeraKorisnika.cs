﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oplan
{
    class ProvjeraKorisnika
    {
        static private korisnik korisnik = null;

        /// <summary>
        /// Provjerava jesu li korisničko ime i lozinka jednaki zapisu u bazi te otvara formu na temelju uloga korisnika.
        /// </summary>
        /// <param name="prijava">Naziv forme za prijavu</param>
        /// <param name="korisnickoIme">Korisničko ime u teksutalnom obliku</param>
        /// <param name="lozinka">Lozinka u tekstualnom obliku</param>
        static public void ProvjeriKorisnika(frmPrijava prijava, string korisnickoIme, string lozinka)
        {
            if (!ProvjeriKorisnickoIme(korisnickoIme))
            {
                MessageBox.Show("Uneseno korisničko ime ne postoji!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (korisnik.lozinka != lozinka)
            {
                MessageBox.Show("Unijeli ste pogrešnu lozinku!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                prijava.Hide();
                if (korisnik.administrator == "Da")
                {
                    frmIzbornik izbornik = new frmIzbornik(true, korisnik.id_korisnik);
                    izbornik.ShowDialog();
                }
                else
                {
                    frmIzbornik izbornik = new frmIzbornik(false, korisnik.id_korisnik);
                    izbornik.ShowDialog();
                }
                prijava.Close();
            } 
        }

        /// <summary>
        /// Provjerava postoji li korisničko ime u bazi podataka.
        /// </summary>
        /// <param name="korisnickoIme">Korisničko ime u tekstualnom obliku</param>
        ///<returns>True ako korisničko ime postoji, false ako ne postoji.</returns>
        static public bool ProvjeriKorisnickoIme(string korisnickoIme)
        {
            using (var db = new EntitiesSettings())
            {
                korisnik = (from k in db.korisnik
                                     where k.korisnicko_ime == korisnickoIme
                                     select k).FirstOrDefault<korisnik>();
                if (korisnik == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
