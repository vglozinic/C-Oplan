﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototip_OPPlan;

namespace oplan
{
    public partial class frmNaziv : Form
    {
        private string nazivPlana;
        private int prijavljeniKorisnik;
        private List<podaci> markeri;
        private List<rute> rute;

        public frmNaziv()
        {
            InitializeComponent();
        }

        public frmNaziv(string naziv)
        {
            InitializeComponent();
            nazivPlana = naziv;
            txtNaziv.Text = nazivPlana;
            this.Text = "Izmjena naziva";
        }

        public frmNaziv(int korisnik, List<podaci> markeri_argument, List<rute> rute_argument)
        {
            InitializeComponent();
            prijavljeniKorisnik = korisnik;
            markeri = markeri_argument;
            rute = rute_argument;
        }

        private void frmNaziv_Load(object sender, EventArgs e)
        {
            if (nazivPlana == null)
            {
                btnPotvrdi.Enabled = false;
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (ProvjeraUnosa.ProvjeriNaziv(txtNaziv.Text))
            {
                if (nazivPlana == null)
                {
                    if (!RadSPlanovima.ProvjeriPlan(txtNaziv.Text))
                    {
                        RadSPlanovima.SpremiPlan(2, nazivPlana, markeri, rute);
                        MessageBox.Show("Uspješno ste spremili plan.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Takav naziv već postoji!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (RadSPlanovima.ProvjeriPlan(txtNaziv.Text) && txtNaziv.Text != nazivPlana)
                    {
                        MessageBox.Show("Takav naziv već postoji!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        RadSPlanovima.PromijeniNaziv(nazivPlana, txtNaziv.Text);
                        MessageBox.Show("Uspješno ste izmijenili naziv.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Naziv može sadržavati slova, brojke i razmak!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                btnPotvrdi.Enabled = false;
            }
            else
            {
                btnPotvrdi.Enabled = true;
            }
        }
    }
}
