using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirforceDataManagementApp
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnOfficersInfo_Click(object sender, EventArgs e)
        {
            frmOfficers frmOfficers = new frmOfficers();
            frmOfficers.Show();
            this.Hide();
        }

        private void BtnAirmenInformation_Click(object sender, EventArgs e)
        {
            frmAirmen frmAirmen = new frmAirmen();
            frmAirmen.Show();
            this.Hide();
        }

        private void BtnAircraftInformation_Click(object sender, EventArgs e)
        {
            frmAircraft frmAircraft = new frmAircraft();
            frmAircraft.Show();
            this.Hide();
        }

        private void BtnOrdnanceInformation_Click(object sender, EventArgs e)
        {
            frmOrdnance frmOrdnance = new frmOrdnance();
            frmOrdnance.Show();
            this.Hide();
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            transactionForm transactionForm = new transactionForm();
            transactionForm.Show();
            this.Hide();
        }

        private void BtnComboData_Click(object sender, EventArgs e)
        {
            frmLoadCombo loadCombo = new frmLoadCombo();
            loadCombo.Show();
            this.Hide();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            rptOfficersInformation rptOfficers = new rptOfficersInformation();
            rptOfficers.ShowDialog();
        }
    }
}
