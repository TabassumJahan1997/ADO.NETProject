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
    public partial class frmAirmen : Form
    {

        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";
        public frmAirmen()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmInsertAirmen insertAirmen = new frmInsertAirmen();
            insertAirmen.ShowDialog();
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

        private void frmAirmen_Load(object sender, EventArgs e)
        {
            ShowAll();
            TradeLoadCombo();
            AirbaseLoadCombo();
            BloodGroupLoadCombo();
            RankLoadCombo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                if (txtFirstName.Text != "" && txtLastName.Text != "" && dtpJoinDate.Value != null && (rdbtnFemale.Checked != false || rdbtnMale.Checked != false) && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    //Image img = Image.FromFile(txtImagePath.Text);
                    //MemoryStream memoryStream = new MemoryStream();
                    //img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"UPDATE tbl_Airmen SET fName=@fname,lName=@lname,rankName=@rank,tradeGroup=@trade,airbase=@airbase,joinDate=@joindate,gender=@gender,bloodGroup=@bg,airmanPhoto=@photo,photoUrl=@url WHERE airmanId=@id", connection);
                    command.Parameters.AddWithValue("@id",txtId.Text);
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
                    //command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray() });

                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox.Image.Save(memoryStream,pictureBox.Image.RawFormat);
                    command.Parameters.AddWithValue("@photo",memoryStream.ToArray());

                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data updated successfully.....");
                    ClearAll();
                    frmAirmen frmAirmen = new frmAirmen();
                    frmAirmen.Show();
                    connection.Close();
                    this.Hide();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM tbl_Airmen WHERE airmanId = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtId.Text = dataReader.GetInt32(0).ToString();
                        txtFirstName.Text = dataReader.GetString(1);
                        txtLastName.Text = dataReader.GetString(2);
                        cmbRank.SelectedValue = dataReader.GetInt32(3);
                        cmbTradeGroup.SelectedValue = dataReader.GetInt32(4);
                        cmbBase.SelectedValue = dataReader.GetInt32(5);
                        dtpJoinDate.Value = dataReader.GetDateTime(6).Date;

                        if (dataReader.GetString(7) == rdbtnFemale.Text)
                        {
                            rdbtnFemale.Checked = true;
                        }
                        if (dataReader.GetString(7) == rdbtnMale.Text)
                        {
                            rdbtnMale.Checked = true;
                        }

                        cmbBloodGroup.SelectedValue = dataReader.GetInt32(8);
                        pictureBox.Image = Image.FromStream(dataReader.GetStream(9));
                        txtImagePath.Text = dataReader.GetString(10);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowAll()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT a.airmanId AS ID, a.fName+' '+a.lName as Name,r.rankName as [Rank],r.basicSalary as Salary,ab.baseName as Base FROM tbl_Airmen a INNER JOIN tbl_Rank r ON a.rankName = r.rankId INNER JOIN tbl_Airbase ab ON a.airbase = ab.baseId INNER JOIN tbl_TradeGroup t ON a.tradeGroup = t.tradeId", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM tbl_Airmen WHERE airmanId = " + txtId.Text + "", connection);
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data deleted successfully.");
                ShowAll();
                ClearAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
