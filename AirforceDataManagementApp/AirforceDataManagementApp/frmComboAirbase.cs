using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirforceDataManagementApp
{
    public partial class frmComboAirbase : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";


        public frmComboAirbase()
        {
            InitializeComponent();
        }

        private void FrmComboAirbase_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO tbl_Airbase VALUES('" + txtAirbase.Text + "')", connection);
            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("New Airbase added.");
            ShowAll();
            connection.Close();
        }

        public void ShowAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Airbase", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            frmLoadCombo frmLoadCombo = new frmLoadCombo();
            frmLoadCombo.Show();
            this.Hide();
        }
    }
}
