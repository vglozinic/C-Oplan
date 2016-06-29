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
    public partial class frmDodajArsenal : Form
    {
        private int id_postrojba = 0;
        private int id_oprema = 0;

        public frmDodajArsenal()
        {
            InitializeComponent();
        }

        public frmDodajArsenal(int postrojba, int oprema)
        {
            InitializeComponent();
            id_postrojba = postrojba;
            id_oprema = oprema;
        }

        private void frmDodajArsenal_Load(object sender, EventArgs e)
        {
            RadSArsenalom.PopuniPostrojbama(cmbPostrojba);
            RadSArsenalom.PopuniOpremom(cmbOprema);
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            if (id_oprema == 0 && id_oprema == 0)
            {
                //novi redak se dodaje
            }
            else
            {
                //postojeći redak
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
