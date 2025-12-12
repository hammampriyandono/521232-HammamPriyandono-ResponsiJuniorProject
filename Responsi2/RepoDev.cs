using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Responsi2
{
    internal class RepoDev : Dev
    {
        private const string conn = "Host=localhost;Username=postgres;Password=usti;Database=Management";
        private static NpgsqlConnection connection;
        private static NpgsqlCommand cmd;
        private static DataTable table;
        public DataGridView dgvData;
        private DataGridViewRow _row;
        
        public RepoDev(DataGridView _dgv)
        {
            dgvData = _dgv;
        }
        public void TampilData()
        {
            connection = new NpgsqlConnection(conn);
            try
            {
                connection.Open();
                dgvData.DataSource = null;
                table = new DataTable();
                cmd = new NpgsqlCommand("SELECT * FROM developer", connection);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                dgvData.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void InsertData(TextBox tbNama, ComboBox cbProyek, ComboBox cbKontrak)
        {
            connection = new NpgsqlConnection(conn);
            try
            {
                connection.Open();
                string sql = "SELECT * FROM insert_dev (:_id_dev :_nama_dev)";
                cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("_id_dev", cbProyek.Text);
                cmd.Parameters.AddWithValue("_nama_dev", tbNama.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Berhasil Ditambahkan");
                    tbNama.Text = null;
                    cbProyek.Text = null;
                    cbKontrak.Text = null;
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateData(TextBox tbNama, ComboBox cbProyek, ComboBox cbKontrak)
        {
            connection = new NpgsqlConnection(conn);
            if(_row == null)
            {
                MessageBox.Show("Pilih data yang akan diupdate");
                return;
            }
            try
            {
                connection.Open();
                string sql = "SELECT * FROM update_dev (:_id_dev :_nama_dev)";
                cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("_id_dev", cbProyek.Text);
                cmd.Parameters.AddWithValue("_nama_dev", tbNama.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Berhasil Diupdate");
                    tbNama.Text = null;
                    cbProyek.Text = null;
                    cbKontrak.Text = null;
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeleteData(TextBox tbNama, ComboBox cbProyek, ComboBox cbKontrak)
        {
            connection = new NpgsqlConnection(conn);
            if (_row == null)
            {
                MessageBox.Show("Pilih data yang akan dihapus");
                return;
            }
            try
            {
                connection.Open();
                string sql = "SELECT * FROM delete_dev (:_id_dev)";
                cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("_id_dev", cbProyek.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Berhasil Dihapus");
                    tbNama.Text = null;
                    cbProyek.Text = null;
                    cbKontrak.Text = null;
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void LoadDev(ComboBox cbProyek, ComboBox cbKontrak)
        {
            connection = new NpgsqlConnection(conn);
            try
            {
                connection.Open();
                cbKontrak.Items.Clear();
                cbProyek.Items.Clear();
                string sql = "SELECT id_dev FROM developer ORDER BY id_dep";
                cmd = new NpgsqlCommand(sql, connection);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbProyek.Items.Add(dr.GetString(0));
                    cbKontrak.Items.Add(dr.GetString(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
