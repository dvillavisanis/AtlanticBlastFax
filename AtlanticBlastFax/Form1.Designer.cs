namespace AtlanticBlastFax
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Btn_LoadNumber = new System.Windows.Forms.Button();
            this.Btn_SendFax = new System.Windows.Forms.Button();
            this.btn_loadDoc = new System.Windows.Forms.Button();
            this.tbFaxCount = new System.Windows.Forms.TextBox();
            this.tbSubjectLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSendingStatus = new System.Windows.Forms.ProgressBar();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTestOnly = new System.Windows.Forms.CheckBox();
            this.tbTestEmail = new System.Windows.Forms.TextBox();
            this.lbTestEmail = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Btn_LoadNumber
            // 
            this.Btn_LoadNumber.Location = new System.Drawing.Point(38, 105);
            this.Btn_LoadNumber.Name = "Btn_LoadNumber";
            this.Btn_LoadNumber.Size = new System.Drawing.Size(102, 23);
            this.Btn_LoadNumber.TabIndex = 0;
            this.Btn_LoadNumber.Text = "Load Numbers";
            this.Btn_LoadNumber.UseVisualStyleBackColor = true;
            this.Btn_LoadNumber.Click += new System.EventHandler(this.Btn_LoadNumber_Click);
            // 
            // Btn_SendFax
            // 
            this.Btn_SendFax.Enabled = false;
            this.Btn_SendFax.Location = new System.Drawing.Point(38, 228);
            this.Btn_SendFax.Name = "Btn_SendFax";
            this.Btn_SendFax.Size = new System.Drawing.Size(75, 23);
            this.Btn_SendFax.TabIndex = 1;
            this.Btn_SendFax.Text = "Blast Fax";
            this.Btn_SendFax.UseVisualStyleBackColor = true;
            this.Btn_SendFax.Click += new System.EventHandler(this.Btn_SendFax_Click);
            // 
            // btn_loadDoc
            // 
            this.btn_loadDoc.Location = new System.Drawing.Point(38, 147);
            this.btn_loadDoc.Name = "btn_loadDoc";
            this.btn_loadDoc.Size = new System.Drawing.Size(102, 19);
            this.btn_loadDoc.TabIndex = 2;
            this.btn_loadDoc.Text = "Load Document";
            this.btn_loadDoc.UseVisualStyleBackColor = true;
            this.btn_loadDoc.Click += new System.EventHandler(this.btn_loadDoc_Click);
            // 
            // tbFaxCount
            // 
            this.tbFaxCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbFaxCount.Location = new System.Drawing.Point(146, 105);
            this.tbFaxCount.Name = "tbFaxCount";
            this.tbFaxCount.Size = new System.Drawing.Size(100, 20);
            this.tbFaxCount.TabIndex = 4;
            // 
            // tbSubjectLine
            // 
            this.tbSubjectLine.Location = new System.Drawing.Point(149, 78);
            this.tbSubjectLine.Name = "tbSubjectLine";
            this.tbSubjectLine.Size = new System.Drawing.Size(231, 20);
            this.tbSubjectLine.TabIndex = 5;
            this.tbSubjectLine.Text = "ISOPROPYL ALCOHOL 70% & 99% Available";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Subject Line";
            // 
            // pbSendingStatus
            // 
            this.pbSendingStatus.Location = new System.Drawing.Point(38, 186);
            this.pbSendingStatus.Name = "pbSendingStatus";
            this.pbSendingStatus.Size = new System.Drawing.Size(455, 23);
            this.pbSendingStatus.TabIndex = 7;
            // 
            // tbCurrent
            // 
            this.tbCurrent.Enabled = false;
            this.tbCurrent.Location = new System.Drawing.Point(272, 105);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.Size = new System.Drawing.Size(100, 20);
            this.tbCurrent.TabIndex = 8;
            // 
            // cbCompany
            // 
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Items.AddRange(new object[] {
            "001",
            "NAS"});
            this.cbCompany.Location = new System.Drawing.Point(149, 42);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(121, 21);
            this.cbCompany.TabIndex = 9;
            this.cbCompany.Text = "001";
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Company";
            // 
            // cbTestOnly
            // 
            this.cbTestOnly.AutoSize = true;
            this.cbTestOnly.Checked = true;
            this.cbTestOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTestOnly.Location = new System.Drawing.Point(12, 12);
            this.cbTestOnly.Name = "cbTestOnly";
            this.cbTestOnly.Size = new System.Drawing.Size(71, 17);
            this.cbTestOnly.TabIndex = 11;
            this.cbTestOnly.Text = "Test Only";
            this.cbTestOnly.UseVisualStyleBackColor = true;
            this.cbTestOnly.CheckedChanged += new System.EventHandler(this.cbTestOnly_CheckedChanged);
            // 
            // tbTestEmail
            // 
            this.tbTestEmail.Location = new System.Drawing.Point(272, 9);
            this.tbTestEmail.Name = "tbTestEmail";
            this.tbTestEmail.Size = new System.Drawing.Size(221, 20);
            this.tbTestEmail.TabIndex = 12;
            this.tbTestEmail.Text = "13056904213@metrofax.com";
            // 
            // lbTestEmail
            // 
            this.lbTestEmail.AutoSize = true;
            this.lbTestEmail.Location = new System.Drawing.Point(210, 12);
            this.lbTestEmail.Name = "lbTestEmail";
            this.lbTestEmail.Size = new System.Drawing.Size(48, 13);
            this.lbTestEmail.TabIndex = 13;
            this.lbTestEmail.Text = "Test Fax";
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(146, 150);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(320, 20);
            this.tbFilename.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Account";
            // 
            // cbAccount
            // 
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(372, 42);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(121, 21);
            this.cbAccount.TabIndex = 15;
            this.cbAccount.Text = "001";
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 269);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAccount);
            this.Controls.Add(this.btn_loadDoc);
            this.Controls.Add(this.lbTestEmail);
            this.Controls.Add(this.tbTestEmail);
            this.Controls.Add(this.cbTestOnly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCompany);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.pbSendingStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSubjectLine);
            this.Controls.Add(this.tbFaxCount);
            this.Controls.Add(this.Btn_SendFax);
            this.Controls.Add(this.Btn_LoadNumber);
            this.Controls.Add(this.tbFilename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Blast Fax";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_LoadNumber;
        private System.Windows.Forms.Button Btn_SendFax;
        private System.Windows.Forms.Button btn_loadDoc;
        private System.Windows.Forms.TextBox tbFaxCount;
        private System.Windows.Forms.TextBox tbSubjectLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbSendingStatus;
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbTestOnly;
        private System.Windows.Forms.TextBox tbTestEmail;
        private System.Windows.Forms.Label lbTestEmail;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAccount;
    }
}

