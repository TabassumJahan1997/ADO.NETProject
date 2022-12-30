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
    public partial class frmInsertAircraft : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";
        public frmInsertAircraft()
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmAircraft frmAircraft = new frmAircraft();
            frmAircraft.Show();
            this.Hide();
        }

        private void frmInsertAircraft_Load(object sender, EventArgs e)
        {
            TypeLoadCombo();
            OriginLoadCombo();
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
                if (txtName.Text != "" && cmbOrigin.SelectedIndex != -1 && cmbType.SelectedIndex != -1  &&  (rdbtnYes.Checked != true || rdbtnNo.Checked != true) && dtpFirstFlight.Text != "" && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    Image img = Image.FromFile(txtImagePath.Text);
                    MemoryStream memoryStream = new MemoryStream();
                    img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"INSERT INTO tbl_Aircraft VALUES(@name,@origin,@type,@inservice,@firstflight,@photo,@url)", connection);
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
                    command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray() });
                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully.....");
                    frmAircraft frmAircraft = new frmAircraft();
                    frmAircraft.Show();
                    frmAircraft.ShowAll();
                    
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
