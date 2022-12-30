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
    public partial class frmOrdnance : Form
    {

        public string connectionString = "Data Source=.;Initial Catalog=AirForceInformationDB;Trusted_connection=True";
        public frmOrdnance()
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


        private void btnExit_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void frmOrdnance_Load(object sender, EventArgs e)
        {
            ShowAll();
            TypeLoadCombo();
            OriginLoadCombo();
        }

        public void ShowAll()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT o.oId AS ID,o.oName AS Name,ot.otName AS Type,o.ordnancePhoto AS Picture FROM tbl_Ordnance o INNER JOIN tbl_OrdnanceType ot ON o.oType = ot.otId", connection);

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM tbl_Ordnance WHERE oId=@id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtId.Text = dataReader.GetInt32(0).ToString();
                        txtName.Text = dataReader.GetString(1);
                        cmbOrigin.SelectedValue = dataReader.GetInt32(2);
                        cmbType.SelectedValue = dataReader.GetInt32(3);
                        txtPrice.Text = dataReader.GetSqlMoney(4).ToString();
                        pictureBox.Image = Image.FromStream(dataReader.GetStream(5));
                        txtImagePath.Text = dataReader.GetString(6);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                if (txtName.Text != "" && cmbOrigin.SelectedIndex != -1 && cmbType.SelectedIndex != -1 && txtPrice.Text != "" && txtImagePath.Text != "" && pictureBox.Image != null)
                {
                    //Image img = Image.FromFile(txtImagePath.Text);
                    //MemoryStream memoryStream = new MemoryStream();
                    //img.Save(memoryStream, ImageFormat.Bmp);

                    SqlCommand command = new SqlCommand(@"UPDATE tbl_Ordnance SET oName=@name,origin=@origin,oType=@type,price=@price,ordnancePhoto=@photo,photoUrl=@url WHERE oId=@id ", connection);
                    command.Parameters.AddWithValue("@id",txtId.Text);
                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@origin", cmbOrigin.SelectedValue);
                    command.Parameters.AddWithValue("@type", cmbType.SelectedValue);
                    command.Parameters.AddWithValue("@price", txtPrice.Text);
                    //command.Parameters.Add(new SqlParameter("@photo", SqlDbType.VarBinary) { Value = memoryStream.ToArray() });

                    MemoryStream memoryStream = new MemoryStream();
                    pictureBox.Image.Save(memoryStream,pictureBox.Image.RawFormat);
                    command.Parameters.AddWithValue("@photo",memoryStream.ToArray());

                    command.Parameters.AddWithValue("@url", txtImagePath.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data Updated successfully.....");
                    frmOrdnance frmOrdnance = new frmOrdnance();
                    frmOrdnance.Show();
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

        public void ClearAll()
        {
            txtId.Clear();
            txtName.Clear();
            cmbOrigin.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            txtPrice.Clear();
            txtImagePath.Clear();
            pictureBox.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM tbl_Ordnance WHERE oId = " + txtId.Text + "", connection);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmInsertOrdnance frmInsertOrdnance = new frmInsertOrdnance();
            frmInsertOrdnance.ShowDialog();
        }
    }
}
