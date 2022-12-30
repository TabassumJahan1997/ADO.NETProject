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
    public partial class frmInsertOrdnance : Form
    {
        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";
        public frmInsertOrdnance()
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT otId,otName FROM tbl_OrdnanceType", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbType.DataSource = dataTable;
            cmbType.DisplayMember = "otName";
            cmbType.ValueMember = "otId";
            connection.Close();
        }

        private void frmInsertOrdnance_Load(object sender, EventArgs e)
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
                if (txtName.Text != "" && cmbOrigin.SelectedIndex != -1 && cmbType.SelectedIndex != -1 && txtPrice.Text!="" && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    Image img = Image.FromFile(txtImagePath.Text);
                    MemoryStream memoryStream = new MemoryStream();
                    img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"INSERT INTO tbl_Ordnance VALUES(@name,@origin,@type,@price,@photo,@url)", connection);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@origin", cmbOrigin.SelectedValue);
                    command.Parameters.AddWithValue("@type", cmbType.SelectedValue);
                    command.Parameters.AddWithValue("@price",txtPrice.Text);
                    command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray()});
                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully.....");
                    frmOrdnance frmOrdnance = new frmOrdnance();
                    frmOrdnance.Show();
                    frmOrdnance.ShowAll();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmOrdnance frmOrdnance = new frmOrdnance();
            frmOrdnance.Show();
            this.Hide();
        }
    }
}
