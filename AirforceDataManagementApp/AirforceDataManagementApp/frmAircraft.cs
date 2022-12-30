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
    public partial class frmAircraft : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";

        public frmAircraft()
        {
            InitializeComponent();
        }

        public void OriginLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT cId,cName FROM tbl_Countries", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbOrigin.DataSource = dataTable;
            cmbOrigin.DisplayMember = "cName";
            cmbOrigin.ValueMember = "cId";
            connection.Close();
        }

        public void TypeLoadCombo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT tId,tName FROM tbl_AircraftType", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbType.DataSource = dataTable;
            cmbType.DisplayMember = "tName";
            cmbType.ValueMember = "tId";
            connection.Close();
        }

        public void ShowAll()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT a.aId AS ID, a.aName AS Name, c.cName AS Origin, t.tName AS Type FROM tbl_Aircraft a INNER JOIN tbl_Countries c ON a.origin = c.cId INNER JOIN tbl_AircraftType t ON a.aType = t.tId", connection);

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


        private void frmAircraft_Load(object sender, EventArgs e)
        {
            ShowAll();
            TypeLoadCombo();
            OriginLoadCombo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmInsertAircraft insertAircraft = new frmInsertAircraft();
            insertAircraft.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM tbl_Aircraft WHERE aId=@id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtId.Text = dataReader.GetInt32(0).ToString();
                        txtName.Text = dataReader.GetString(1);
                        cmbOrigin.SelectedValue = dataReader.GetInt32(2);
                        cmbType.SelectedValue = dataReader.GetInt32(3);
                       

                        //SqlCommand inServicecmd = new SqlCommand("SELECT isInService FROM tbl_Aircraft WHERE aId=@id", connection);
                        //bool isInService = (bool)0;
                        //isInService = Convert.ToBoolean(inServicecmd);
                        //if (isInService == true)
                        //{
                        //    Convert.ToBoolean(rdbtnYes.Checked);
                        //}
                        //if (isInService == false)
                        //{
                        //    Convert.ToBoolean(rdbtnNo.Checked);
                        //}

                        if (dataReader.GetBoolean(4).ToString() == "1")
                        {
                            rdbtnYes.Checked = true;
                        }

                        if (dataReader.GetBoolean(4).ToString() == "0")
                        {
                            rdbtnNo.Checked = true;
                        }
                        dtpFirstFlight.Value = dataReader.GetDateTime(5).Date;
                        pictureBox.Image = Image.FromStream(dataReader.GetStream(6));
                        txtImagePath.Text = dataReader.GetString(7);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\nPlease try again .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM tbl_Aircraft WHERE aId = " + txtId.Text + "", connection);
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

        public void ClearAll()
        {
            txtId.Clear();
            txtName.Clear();
            cmbOrigin.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            rdbtnNo.Checked = false;
            rdbtnYes.Checked = false;
            dtpFirstFlight.Text = "";
            txtImagePath.Clear();
            pictureBox.Image = null;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                if (txtName.Text != "" && cmbOrigin.SelectedIndex != -1 && cmbType.SelectedIndex != -1 && (rdbtnYes.Checked != true || rdbtnNo.Checked != true) && dtpFirstFlight.Text != "" && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    //Image img = Image.FromFile(txtImagePath.Text);
                    //MemoryStream memoryStream = new MemoryStream();
                    //img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"UPDATE tbl_Aircraft SET aName=@name,origin=@origin,aType=@type,isInService=@inservice,firstFlight=@firstflight,aircraftPhoto=@photo,photoUrl=@url WHERE aId=@id", connection);
                    command.Parameters.AddWithValue("@id",txtId.Text);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@origin", cmbOrigin.SelectedValue);
                    command.Parameters.AddWithValue("@type", cmbType.SelectedValue);
                    if (rdbtnYes.Checked == true)
                    {
                        command.Parameters.AddWithValue("@inservice", 1);
                    }
                    if (rdbtnNo.Checked == true)
                    {
                        command.Parameters.AddWithValue("@inservice", 0);
                    }
                    command.Parameters.AddWithValue("@firstflight", dtpFirstFlight.Value.Date);
                    //command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray() });

                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox.Image.Save(memoryStream,pictureBox.Image.RawFormat);
                    command.Parameters.AddWithValue("@photo",memoryStream.ToArray());

                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data updated successfully.....");
                    frmAircraft frmAircraft = new frmAircraft();
                    frmAircraft.Show();
                    this.Hide();
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
    }
}
