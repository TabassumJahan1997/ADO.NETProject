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
    public partial class frmLoadCombo : Form
    {
        public frmLoadCombo()
        {
            InitializeComponent();
        }

        private void BtnRank_Click(object sender, EventArgs e)
        {
            frmComboRank comboRank = new frmComboRank();
            comboRank.ShowDialog();
        }

        private void BtnBranch_Click(object sender, EventArgs e)
        {
            frmComboBranch comboBranch = new frmComboBranch();
            comboBranch.ShowDialog();
        }

        private void BtnAirbase_Click(object sender, EventArgs e)
        {
            frmComboAirbase comboAirbase = new frmComboAirbase();
            comboAirbase.ShowDialog();
        }

        private void BtnReligion_Click(object sender, EventArgs e)
        {

        }

        private void BtnAirmanRank_Click(object sender, EventArgs e)
        {

        }

        private void BtnOrigin_Click(object sender, EventArgs e)
        {
            frmOriginCountries originCountries = new frmOriginCountries();
            originCountries.ShowDialog();
        }

        private void BtnBloodGroup_Click(object sender, EventArgs e)
        {
            frmComboBloodGroup comboBloodGroup = new frmComboBloodGroup();
            comboBloodGroup.ShowDialog();
        }

        private void BtnTradeGroup_Click(object sender, EventArgs e)
        {
            frmComboTradeGroup comboTradeGroup = new frmComboTradeGroup();
            comboTradeGroup.ShowDialog();
        }

        private void BtnOrdnanceType_Click(object sender, EventArgs e)
        {
            frmComboOrdnanceType comboOrdnanceType = new frmComboOrdnanceType();
            comboOrdnanceType.ShowDialog();
        }

        private void BtnAircraftType_Click(object sender, EventArgs e)
        {
            frmComboAircraftType comboAircraftType = new frmComboAircraftType();
            comboAircraftType.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }
    }
}
