namespace AirforceDataManagementApp
{
    partial class frmLoadCombo
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRank = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAircraftType = new System.Windows.Forms.Button();
            this.btnOrdnanceType = new System.Windows.Forms.Button();
            this.btnTradeGroup = new System.Windows.Forms.Button();
            this.btnBloodGroup = new System.Windows.Forms.Button();
            this.btnOrigin = new System.Windows.Forms.Button();
            this.btnAirbase = new System.Windows.Forms.Button();
            this.btnBranch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 101);
            this.panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(591, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 57);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMBO BOX DATA";
            // 
            // btnRank
            // 
            this.btnRank.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRank.Location = new System.Drawing.Point(0, 0);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(204, 48);
            this.btnRank.TabIndex = 1;
            this.btnRank.Text = "OFFICER\'S RANK";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.BtnRank_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnAircraftType);
            this.panel2.Controls.Add(this.btnOrdnanceType);
            this.panel2.Controls.Add(this.btnTradeGroup);
            this.panel2.Controls.Add(this.btnBloodGroup);
            this.panel2.Controls.Add(this.btnOrigin);
            this.panel2.Controls.Add(this.btnAirbase);
            this.panel2.Controls.Add(this.btnBranch);
            this.panel2.Controls.Add(this.btnRank);
            this.panel2.Location = new System.Drawing.Point(224, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 473);
            this.panel2.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBack.Location = new System.Drawing.Point(0, 391);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(204, 53);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnAircraftType
            // 
            this.btnAircraftType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAircraftType.Location = new System.Drawing.Point(0, 342);
            this.btnAircraftType.Name = "btnAircraftType";
            this.btnAircraftType.Size = new System.Drawing.Size(204, 49);
            this.btnAircraftType.TabIndex = 2;
            this.btnAircraftType.Text = "AIRCRAFT TYPE";
            this.btnAircraftType.UseVisualStyleBackColor = true;
            this.btnAircraftType.Click += new System.EventHandler(this.BtnAircraftType_Click);
            // 
            // btnOrdnanceType
            // 
            this.btnOrdnanceType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdnanceType.Location = new System.Drawing.Point(0, 291);
            this.btnOrdnanceType.Name = "btnOrdnanceType";
            this.btnOrdnanceType.Size = new System.Drawing.Size(204, 51);
            this.btnOrdnanceType.TabIndex = 2;
            this.btnOrdnanceType.Text = "ORDNANCE TYPE";
            this.btnOrdnanceType.UseVisualStyleBackColor = true;
            this.btnOrdnanceType.Click += new System.EventHandler(this.BtnOrdnanceType_Click);
            // 
            // btnTradeGroup
            // 
            this.btnTradeGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTradeGroup.Location = new System.Drawing.Point(0, 243);
            this.btnTradeGroup.Name = "btnTradeGroup";
            this.btnTradeGroup.Size = new System.Drawing.Size(204, 48);
            this.btnTradeGroup.TabIndex = 2;
            this.btnTradeGroup.Text = "TRADE GROUP";
            this.btnTradeGroup.UseVisualStyleBackColor = true;
            this.btnTradeGroup.Click += new System.EventHandler(this.BtnTradeGroup_Click);
            // 
            // btnBloodGroup
            // 
            this.btnBloodGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBloodGroup.Location = new System.Drawing.Point(0, 195);
            this.btnBloodGroup.Name = "btnBloodGroup";
            this.btnBloodGroup.Size = new System.Drawing.Size(204, 48);
            this.btnBloodGroup.TabIndex = 2;
            this.btnBloodGroup.Text = "BLOOD GROUP";
            this.btnBloodGroup.UseVisualStyleBackColor = true;
            this.btnBloodGroup.Click += new System.EventHandler(this.BtnBloodGroup_Click);
            // 
            // btnOrigin
            // 
            this.btnOrigin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrigin.Location = new System.Drawing.Point(0, 144);
            this.btnOrigin.Name = "btnOrigin";
            this.btnOrigin.Size = new System.Drawing.Size(204, 51);
            this.btnOrigin.TabIndex = 2;
            this.btnOrigin.Text = "ORIGIN COUNTRY";
            this.btnOrigin.UseVisualStyleBackColor = true;
            this.btnOrigin.Click += new System.EventHandler(this.BtnOrigin_Click);
            // 
            // btnAirbase
            // 
            this.btnAirbase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAirbase.Location = new System.Drawing.Point(0, 96);
            this.btnAirbase.Name = "btnAirbase";
            this.btnAirbase.Size = new System.Drawing.Size(204, 48);
            this.btnAirbase.TabIndex = 2;
            this.btnAirbase.Text = "AIRBASE";
            this.btnAirbase.UseVisualStyleBackColor = true;
            this.btnAirbase.Click += new System.EventHandler(this.BtnAirbase_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBranch.Location = new System.Drawing.Point(0, 48);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(204, 48);
            this.btnBranch.TabIndex = 2;
            this.btnBranch.Text = "BRANCH";
            this.btnBranch.UseVisualStyleBackColor = true;
            this.btnBranch.Click += new System.EventHandler(this.BtnBranch_Click);
            // 
            // frmLoadCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLoadCombo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadCombo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAircraftType;
        private System.Windows.Forms.Button btnTradeGroup;
        private System.Windows.Forms.Button btnBloodGroup;
        private System.Windows.Forms.Button btnAirbase;
        private System.Windows.Forms.Button btnBranch;
        private System.Windows.Forms.Button btnOrigin;
        private System.Windows.Forms.Button btnOrdnanceType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
    }
}