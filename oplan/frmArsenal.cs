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
    public partial class frmArsenal : Form
    {
        private int filter = 1;

        public frmArsenal()
        {
            InitializeComponent();
        }

        private void PopuniPostrojbama()
        {
            using (var db = new EntitiesSettings())
            {
                var prikazaniTekst = (from p in db.postrojba
                                      join v in db.vrsta on p.id_vrsta equals v.id_vrsta
                                      join t in db.tip_postrojbe on p.id_tip equals t.id_tip
                                      select new
                                      {
                                          id = p.id_postrojba,
                                          tekst = v.naziv + " - " + t.naziv
                                      }).ToList();

                cmbFilter.DataSource = prikazaniTekst;
                cmbFilter.ValueMember = "id";
                cmbFilter.DisplayMember = "tekst";
            }
        }

        private void PopuniOpremom()
        {
            using (var db = new EntitiesSettings())
            {
                cmbFilter.DataSource = db.oprema.ToList();
                cmbFilter.DisplayMember = "model";
                cmbFilter.ValueMember = "id_oprema";
            }
        }

        private void frmArsenal_Load(object sender, EventArgs e)
        {
            rdbPostrojba.Checked = true;
            PopuniPostrojbama();

            RadSArsenalom.PrikaziArsenal(filter, dgvArsenal, (int)cmbFilter.SelectedValue);
        }

        private void btnDodajDodjelu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIzmijeniDodjelu_Click(object sender, EventArgs e)
        {

        }

        private void btnIzbrisiDodjelu_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOpis_Click(object sender, EventArgs e)
        {

        }

        private void rdbPostrojba_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbPostrojba.Checked == true)
            {
                PopuniPostrojbama();
            }
            else
            {
                PopuniOpremom();
            }
        }
    }
}
