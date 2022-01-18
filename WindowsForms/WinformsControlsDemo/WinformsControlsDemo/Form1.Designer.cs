
namespace WinformsControlsDemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblTechnology = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnOther = new System.Windows.Forms.RadioButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cboxLocations = new System.Windows.Forms.ComboBox();
            this.lstBoxTechnology = new System.Windows.Forms.ListBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trainee Registration Form";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(81, 124);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(155, 25);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Enter your name";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(81, 341);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(160, 25);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Choose Location";
            // 
            // lblTechnology
            // 
            this.lblTechnology.AutoSize = true;
            this.lblTechnology.Location = new System.Drawing.Point(81, 393);
            this.lblTechnology.Name = "lblTechnology";
            this.lblTechnology.Size = new System.Drawing.Size(189, 25);
            this.lblTechnology.TabIndex = 1;
            this.lblTechnology.Text = "Choose Technology";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(81, 176);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(137, 25);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "Select Gender";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(81, 229);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(176, 25);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Enter your address";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(280, 119);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 29);
            this.txtName.TabIndex = 0;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Location = new System.Drawing.Point(280, 171);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(80, 29);
            this.rbtnMale.TabIndex = 1;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(366, 171);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(102, 29);
            this.rbtnFemale.TabIndex = 2;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.Location = new System.Drawing.Point(474, 171);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(135, 29);
            this.rbtnOther.TabIndex = 3;
            this.rbtnOther.TabStop = true;
            this.rbtnOther.Text = "Non-Binary";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(280, 226);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(270, 84);
            this.txtAddress.TabIndex = 4;
            // 
            // cboxLocations
            // 
            this.cboxLocations.FormattingEnabled = true;
            this.cboxLocations.Items.AddRange(new object[] {
            "Hyderabad",
            "Chennai",
            "Bengaluru",
            "Noida",
            "Kolkata",
            "Kochin",
            "Pune",
            "Mumbai",
            "Delhi"});
            this.cboxLocations.Location = new System.Drawing.Point(280, 341);
            this.cboxLocations.Name = "cboxLocations";
            this.cboxLocations.Size = new System.Drawing.Size(270, 32);
            this.cboxLocations.TabIndex = 5;
            // 
            // lstBoxTechnology
            // 
            this.lstBoxTechnology.FormattingEnabled = true;
            this.lstBoxTechnology.ItemHeight = 24;
            this.lstBoxTechnology.Items.AddRange(new object[] {
            ".NET",
            "Java",
            "Testing"});
            this.lstBoxTechnology.Location = new System.Drawing.Point(280, 403);
            this.lstBoxTechnology.Name = "lstBoxTechnology";
            this.lstBoxTechnology.Size = new System.Drawing.Size(270, 100);
            this.lstBoxTechnology.TabIndex = 6;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(280, 532);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(270, 45);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Location = new System.Drawing.Point(681, 124);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(231, 453);
            this.lblMessage.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 760);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lstBoxTechnology);
            this.Controls.Add(this.cboxLocations);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.rbtnOther);
            this.Controls.Add(this.rbtnFemale);
            this.Controls.Add(this.rbtnMale);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblTechnology);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblTechnology;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.RadioButton rbtnOther;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cboxLocations;
        private System.Windows.Forms.ListBox lstBoxTechnology;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblMessage;
    }
}

