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
    public partial class frmInsertAirmen : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";
        public frmInsertAirmen()
        {
            InitializeComponent();
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

        public void TradeLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT tradeId,tradeName FROM tbl_TradeGroup", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbTradeGroup.DataSource = dataTable;
            cmbTradeGroup.DisplayMember = "tradeName";
            cmbTradeGroup.ValueMember = "tradeId";
            connection.Close();
        }
        private void frmInsertAirmen_Load(object sender, EventArgs e)
        {
            TradeLoadCombo();
            AirbaseLoadCombo();
            BloodGroupLoadCombo();
            RankLoadCombo();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    this.pictureBox.Image = image;
                    txtImagePath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                if (txtFirstName.Text != "" && txtLastName.Text != "" && dtpJoinDate.Value != null && (rdbtnFemale.Checked != false || rdbtnMale.Checked != false) && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    Image img = Image.FromFile(txtImagePath.Text);
                    MemoryStream memoryStream = new MemoryStream();
                    img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"INSERT INTO tbl_Airmen VALUES(@fname,@lname,@rank,@trade,@airbase,@joindate,@gender,@bg,@photo,@url)", connection);
                    command.Parameters.AddWithValue("@fname", txtFirstName.Text);
                    command.Parameters.AddWithValue("@lname", txtLastName.Text);
                    command.Parameters.AddWithValue("@rank", cmbRank.SelectedValue);
                    command.Parameters.AddWithValue("@trade", cmbTradeGroup.SelectedValue);
                    command.Parameters.AddWithValue("@airbase", cmbBase.SelectedValue); 
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
                    frmAirmen frmAirmen = new frmAirmen();
                    frmAirmen.Show();
                    frmAirmen.ShowAll();
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
            cmbTradeGroup.SelectedIndex = -1;
            cmbBase.SelectedIndex = -1;
            cmbBloodGroup.SelectedIndex = -1;
            rdbtnFemale.Checked = false;
            rdbtnMale.Checked = false;
            txtImagePath.Clear();
            pictureBox.Image = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmAirmen frmAirmen = new frmAirmen();
            frmAirmen.Show();
            this.Hide();
        }
    }
}
