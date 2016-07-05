using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oplan
{
    public partial class frmIzbornik : Form
    {
        private int prijavljeniKorisnik;

        /// <summary>
        /// Konstruktor klase koji na temelju uloge korisnika skriva ili prikazuje opcije za administraciju.
        /// </summary>
        /// <param name="administrator">Administracijsko stanje u kojem je trenutni korisnik</param>
        /// <param name="id">ID trenutno prijavljenog korisnika</param>
        public frmIzbornik(bool administrator, int id)
        {
            InitializeComponent();
            prijavljeniKorisnik = id;
            if (!administrator)
            {
                msGlavni.Items.Remove(miAdministracija);
            }
        }

        private void miAdministracijaPostrojbe_Click(object sender, EventArgs e)
        {
            frmPostrojbe postrojbe = new frmPostrojbe();
            postrojbe.ShowDialog();
        }

        private void miAdministracijaKorisnici_Click(object sender, EventArgs e)
        {
            frmKorisnici korisnici = new frmKorisnici(prijavljeniKorisnik);
            korisnici.ShowDialog();
        }

        private void miIzbornikIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miIzbornikNoviPlan_Click(object sender, EventArgs e)
        {

        }

        private void miIzbornikUcitajPlan_Click(object sender, EventArgs e)
        {

        }

        private void miPomocPrikaz_Click(object sender, EventArgs e)
        {
            string putanja = @"../../help/oplan.chm";
            if (System.IO.File.Exists(putanja))
            {
                Help.ShowHelp(this, putanja);
            }
        }

        private void miPomocOPLAN_Click(object sender, EventArgs e)
        {
            frmAbout oNama = new frmAbout();
            oNama.ShowDialog();
        }

        private void miStatistikaZemlje_Click(object sender, EventArgs e)
        {

        }

        private void miStatistikaTip_Click(object sender, EventArgs e)
        {

        }

        private void miIzbornikArsenal_Click(object sender, EventArgs e)
        {
            frmArsenal pregledArsenala = new frmArsenal();
            pregledArsenala.ShowDialog();
        }

        private void miIzboenikOprema_Click(object sender, EventArgs e)
        {
            frmOprema pregledOpreme = new frmOprema();
            pregledOpreme.ShowDialog();
        }
    }
}
