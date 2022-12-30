using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirforceDataManagementApp
{
    public partial class frmInsertOfficers : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";


        public frmInsertOfficers()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmInsertOfficers_Load(object sender, EventArgs e)
        {
            RankLoadCombo();
            BranchLoadCombo();
            BloodGroupLoadCombo();
            AirbaseLoadCombo();
        }

        public void RankLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT rankId,rankName,basicSalary FROM tbl_Rank", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbRank.DataSource = dataTable;
            cmbRank.DisplayMember = "rankName";
            cmbRank.ValueMember = "rankId";
            connection.Close();
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

        public void BloodGroupLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT bgId,bgName FROM tbl_BloodGroup", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbBloodGroup.DataSource = dataTable;
            cmbBloodGroup.DisplayMember = "bgName";
            cmbBloodGroup.ValueMember = "bgId";
            connection.Close();
        }

        public void AirbaseLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(" SELECT baseId,baseName FROM tbl_Airbase", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbBase.DataSource = dataTable;
            cmbBase.DisplayMember = "baseName";
            cmbBase.ValueMember = "baseId";
            connection.Close();
        }


        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    this.pictureBox1.Image = image;
                    txtImagePath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                if (txtFirstName.Text != "" && txtLastName.Text != ""  && dtpJoinDate.Value != null && (rdbtnFemale.Checked == false || rdbtnMale.Checked == false) && txtImagePath.Text != "" && pictureBox1.Image != null)
                {
                    Image img = Image.FromFile(txtImagePath.Text);
                    MemoryStream memoryStream = new MemoryStream();
                    img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"INSERT INTO tbl_Officers VALUES(@fname,@lname,@rank,@branch,@base,@joindate,@gender,@bg,@photo,@url)", connection);
                    command.Parameters.AddWithValue("@fname", txtFirstName.Text);
                    command.Parameters.AddWithValue("@lname", txtLastName.Text);
                    command.Parameters.AddWithValue("@rank", cmbRank.SelectedValue);
                    command.Parameters.AddWithValue("@branch", cmbBranch.SelectedValue);
                    command.Parameters.AddWithValue("@base", cmbBase.SelectedValue);
                    command.Parameters.AddWithValue("@joindate", dtpJoinDate.Value.Date);
                    if (rdbtnFemale.Checked == true)
                    {
                        command.Parameters.AddWithValue("@gender", rdbtnFemale.Text);
                    }
                    if (rdbtnMale.Checked == true)
                    {
                        command.Parameters.AddWithValue("@gender", rdbtnMale.Text);
                    }
                   
                    command.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedValue);
                    command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray() });
                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully.....");
                    ClearAll();
                    frmOfficers frmOfficers = new frmOfficers();
                    frmOfficers.Show();
                    frmOfficers.ShowAll();
                    connection.Close();
    
                }
                else
                {
                    MessageBox.Show("Please enter data into all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ClearAll()
        {
          
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbRank.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            cmbBase.SelectedIndex = -1;
            cmbBloodGroup.SelectedIndex = -1;
            rdbtnFemale.Checked = false;
            rdbtnMale.Checked = false;
            txtImagePath.Clear();
            pictureBox1.Image = null;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
