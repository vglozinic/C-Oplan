using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oplan
{
    class RadSArsenalom
    {
        static public void PrikaziArsenal(int filter, DataGridView dgvArsenal, int id)
        {
            if (filter == 1)
            {
                PrikaziPoPostrojbama(dgvArsenal, id);
            }
            else
            {
                PrikaziPoOpremi(dgvArsenal, id);
            } 
        }

        static public void PrikaziPoPostrojbama(DataGridView dgvArsenal, int id_postrojba)
        {
            using (var db = new EntitiesSettings())
            {
                //upit

                dgvArsenal.DataSource = upit.ToList();

                dgvArsenal.Columns[0].HeaderText = "ID postrojbe";
                dgvArsenal.Columns[3].HeaderText = "Izdržljivost";

                dgvArsenal.Columns[2].Width = 140;
            }
        }

        static public void PrikaziPoOpremi(DataGridView dgvArsenal, int id_oprema)
        {
            using (var db = new EntitiesSettings())
            {
                //upit

                dgvArsenal.DataSource = upit.ToList();

                dgvArsenal.Columns[0].HeaderText = "ID postrojbe";
                dgvArsenal.Columns[3].HeaderText = "Izdržljivost";

                dgvArsenal.Columns[2].Width = 140;
            }
        }

        static public void DodajPostrojbu(DataGridView dgvPostrojbe)
        {
            frmDodajArsenal formaArsenal = new frmDodajArsenal();
            formaArsenal.ShowDialog();
        }
    }
}
