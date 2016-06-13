﻿using System;
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
    public partial class frmPrijava : Form
    {
        private string korisnicko_ime;
        private string lozinka;

        public frmPrijava()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            korisnicko_ime = txtKorime.Text;
            lozinka = txtLozinka.Text;

            if ( string.IsNullOrEmpty(korisnicko_ime) || string.IsNullOrEmpty(lozinka) )
            {
                MessageBox.Show("Nisu unesena potrebna polja!");
            }
            else
            {
                if ( ProvjeraUnosa.ProvjeriTekst(korisnicko_ime) || ProvjeraUnosa.ProvjeriTekst(lozinka) )
                {
                    this.Hide();
                    ProvjeraKorisnika.ProvjeriKorisnika(korisnicko_ime, lozinka);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unesena polja nisu u dobrom obliku");
                }
            }
        }
    }
}
