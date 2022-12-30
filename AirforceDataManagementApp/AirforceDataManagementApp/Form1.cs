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
    public partial class transactionForm : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";


        public transactionForm()
        {
            InitializeComponent();
        }

        public void BranchLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT branchId,branchName FROM tbl_Branch", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbBranch.DataSource = dataTable;
            cmbBranch.DisplayMember = "branchName";
            cmbBranch.ValueMember = "branchId";
            connection.Close();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            BranchLoadCombo();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = "INSERT INTO tbl_Airbase_Airman VALUES(@baseName,@baseArea) SELECT @@IDENTITY";

                command.Parameters.AddWithValue("@baseName", txtBaseName.Text);
                command.Parameters.AddWithValue("@baseArea", txtArea.Text);

                int id = Convert.ToInt32(command.ExecuteScalar());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["cmbBranch"].Value != null && dataGridView1.Rows[i].Cells["txtairmanName"].Value != null)
                    {
                        SqlCommand command2 = new SqlCommand();
                        command2.Connection = connection;
                        command2.Transaction = transaction;
                        command2.CommandText = "INSERT INTO tbl_Airbase_Branch_Airman(airbaseId,branchId,airmanName) VALUES(@airbaseId,@branchId,@airmanName)";
                        command2.Parameters.AddWithValue("@airbaseId", id);
                        command2.Parameters.AddWithValue("@branchId", dataGridView1.Rows[i].Cells["cmbBranch"].Value);
                        command2.Parameters.AddWithValue("@airmanName", dataGridView1.Rows[i].Cells["txtairmanName"].Value);
                        command2.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                MessageBox.Show("Data saved successfully!!!!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message + "\nData not saved!!!!");
            }
            connection.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }
    }
}
