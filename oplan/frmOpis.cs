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
    public partial class frmOpis : Form
    {
        private string model;
        private string opis;

        public frmOpis()
        {
            InitializeComponent();
        }

        public frmOpis(string proslijedeniModel, string proslijedeniOpis)
        {
            InitializeComponent();
            model = proslijedeniModel;
            opis = proslijedeniOpis;
        }

        private void frmOpis_Load(object sender, EventArgs e)
        {
            this.Text = "Detaljniji opis za " + model;
            this.ucCitac.Opis = opis;
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
