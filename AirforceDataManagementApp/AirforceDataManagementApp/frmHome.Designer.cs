namespace AirforceDataManagementApp
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnComboData = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnOrdnanceInformation = new System.Windows.Forms.Button();
            this.btnAircraftInformation = new System.Windows.Forms.Button();
            this.btnAirmenInformation = new System.Windows.Forms.Button();
            this.btnOfficersInfo = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Sienna;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 153);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(869, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "AIRFORCE INFORMATION MANAGEMENT APPLICATION";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnComboData);
            this.panel2.Controls.Add(this.btnTransaction);
            this.panel2.Controls.Add(this.btnOrdnanceInformation);
            this.panel2.Controls.Add(this.btnAircraftInformation);
            this.panel2.Controls.Add(this.btnAirmenInformation);
            this.panel2.Controls.Add(this.btnOfficersInfo);
            this.panel2.Location = new System.Drawing.Point(423, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 542);
            this.panel2.TabIndex = 1;
            // 
            // btnComboData
            // 
            this.btnComboData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComboData.Location = new System.Drawing.Point(0, 324);
            this.btnComboData.Name = "btnComboData";
            this.btnComboData.Size = new System.Drawing.Size(343, 58);
            this.btnComboData.TabIndex = 0;
            this.btnComboData.Text = "COMBOBOX DATA";
            this.btnComboData.UseVisualStyleBackColor = true;
            this.btnComboData.Click += new System.EventHandler(this.BtnComboData_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransaction.Location = new System.Drawing.Point(0, 266);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(343, 58);
            this.btnTransaction.TabIndex = 0;
            this.btnTransaction.Text = "TRANSACTION ";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.BtnTransaction_Click);
            // 
            // btnOrdnanceInformation
            // 
            this.btnOrdnanceInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdnanceInformation.Location = new System.Drawing.Point(0, 199);
            this.btnOrdnanceInformation.Name = "btnOrdnanceInformation";
            this.btnOrdnanceInformation.Size = new System.Drawing.Size(343, 67);
            this.btnOrdnanceInformation.TabIndex = 0;
            this.btnOrdnanceInformation.Text = "ORDNANCE INFORMATION";
            this.btnOrdnanceInformation.UseVisualStyleBackColor = true;
            this.btnOrdnanceInformation.Click += new System.EventHandler(this.BtnOrdnanceInformation_Click);
            // 
            // btnAircraftInformation
            // 
            this.btnAircraftInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAircraftInformation.Location = new System.Drawing.Point(0, 132);
            this.btnAircraftInformation.Name = "btnAircraftInformation";
            this.btnAircraftInformation.Size = new System.Drawing.Size(343, 67);
            this.btnAircraftInformation.TabIndex = 0;
            this.btnAircraftInformation.Text = "AIRCRAFT INFORMATION";
            this.btnAircraftInformation.UseVisualStyleBackColor = true;
            this.btnAircraftInformation.Click += new System.EventHandler(this.BtnAircraftInformation_Click);
            // 
            // btnAirmenInformation
            // 
            this.btnAirmenInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAirmenInformation.Location = new System.Drawing.Point(0, 68);
            this.btnAirmenInformation.Name = "btnAirmenInformation";
            this.btnAirmenInformation.Size = new System.Drawing.Size(343, 64);
            this.btnAirmenInformation.TabIndex = 0;
            this.btnAirmenInformation.Text = "AIRMEN INFORMATION";
            this.btnAirmenInformation.UseVisualStyleBackColor = true;
            this.btnAirmenInformation.Click += new System.EventHandler(this.BtnAirmenInformation_Click);
            // 
            // btnOfficersInfo
            // 
            this.btnOfficersInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOfficersInfo.Location = new System.Drawing.Point(0, 0);
            this.btnOfficersInfo.Name = "btnOfficersInfo";
            this.btnOfficersInfo.Size = new System.Drawing.Size(343, 68);
            this.btnOfficersInfo.TabIndex = 0;
            this.btnOfficersInfo.Text = "OFFICER\'S INFORMATION";
            this.btnOfficersInfo.UseVisualStyleBackColor = true;
            this.btnOfficersInfo.Click += new System.EventHandler(this.BtnOfficersInfo_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(0, 380);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(343, 65);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "REPORT";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 443);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(343, 65);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 745);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHome";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnComboData;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnOrdnanceInformation;
        private System.Windows.Forms.Button btnAircraftInformation;
        private System.Windows.Forms.Button btnAirmenInformation;
        private System.Windows.Forms.Button btnOfficersInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReport;
    }
}