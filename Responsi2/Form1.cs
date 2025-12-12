using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Responsi2
{
    public partial class Form1 : Form
    {
        public DataTable table;
        public DataGridViewRow _row;
        RepoDev repoDev;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView dgvData = null;
            repoDev = new RepoDev(dgvData);
            repoDev.TampilData();
            repoDev.LoadDev(cbProyek, cbKontrak);
        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            repoDev.InsertData(tbNama, cbProyek, cbKontrak);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            repoDev.UpdateData(tbNama, cbProyek, cbKontrak);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            repoDev.DeleteData(tbNama,cbProyek, cbKontrak);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _row = this.dgvData.Rows[e.RowIndex];
                cbProyek.Text = _row.Cells[0].Value.ToString();
                tbNama.Text = _row.Cells[1].Value.ToString();
                cbKontrak.Text = _row.Cells[2].Value.ToString();
            }
        }
    }
}
